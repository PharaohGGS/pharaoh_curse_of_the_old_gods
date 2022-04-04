using System;
using Pharaoh.Tools;
using Pharaoh.Tools.Debug;
using UnityEngine;
using UnityEngine.Events;
using MessageType = Pharaoh.Tools.Debug.MessageType;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Pharaoh.Gameplay.Components.Movement
{
    [RequireComponent(typeof(Rigidbody2D))] //auto creates a Rigidbody2D component when attaching this component
    public class PlayerMovement : MonoBehaviour
    {
        private readonly Quaternion RightRotation = Quaternion.Euler(new Vector3(0f, 89.9f, 0f));
        private readonly Quaternion LeftRotationIdle = Quaternion.Euler(new Vector3(0f, -135f, 0f));
        private readonly Quaternion LeftRotationRunning = Quaternion.Euler(new Vector3(0f, -90.1f, 0f));

        private Rigidbody2D _rigidbody;
        private Vector2 _movementInput;
        private Vector2 _smoothMovement;
        private Quaternion _rotation = Quaternion.Euler(new Vector3(0f, 89.9f, 0f)); //used to compute the player model rotation
        private float _groundCheckLength = 0.05f;
        private float _previousGravityScale;
        private float _jumpClock = 0f; //used to measure for how long the jump input is held
        private float _dashClock = 0f; //used to measure for how long the dash occurs
        private float _smoothInput = 0.03f;
        private float _turnSpeed = 7f; //value defined with Cl?mence
        private int _defaultLayer;
        private int _swarmDashLayer;
        private bool _isRunning = false;
        private bool _isDashing = false;
        private bool _hasDashedInAir = false;
        private bool _isJumping = false;
        private bool _noclip; //DEBUG
        private bool _canMove = true;
        private bool _isHooked = false;
        private bool _isPullingBlock = false;
        private bool _isHooking = false;

        public bool isFacingRight { get; private set; } = true;
        public bool isGrounded { get; private set; } = false;

        public bool IsRunning { get => _isRunning; }
        public bool IsDashing { get => _isDashing; }
        public bool IsJumping { get => _isJumping; }
        public bool IsFacingRight { get => isFacingRight; set => isFacingRight = value; }
        public bool IsPullingBlock { get => _isPullingBlock; private set => _isPullingBlock = value; }
        public bool IsHooking { get => _isHooking; set => _isHooking = value; }

        [Header("Input Reader")]
        public InputReader inputReader;

        [Header("Player Movement Data")]
        public PlayerMovementData metrics;

        [SerializeField, Header("Hook Events")]
        private HookBehaviourEvents hookEvents;

        [Header("Ground Detection")]
        [Tooltip("Rightmost ground check")]
        public Transform rightGroundCheck;
        [Tooltip("leftmost ground check")]
        public Transform leftGroundCheck;
        public LayerMask groundLayer;

        [Header("Animations")]
        [Tooltip("Animator controlling the player")]
        public Animator animator;
        [Tooltip("Model transform to turn the player around")]
        public Transform modelTransform;

        [Header("Dash Detection")]
        [SerializeField] private LayerMask dashStunLayer;
        [SerializeField] private StunData dashStunData;
        [SerializeField] private UnityEvent<GameObject, StunData> onDashStun;

        private bool _canJumpHook;

        private void Awake()
        {
            _defaultLayer = LayerMask.NameToLayer("Player");
            _swarmDashLayer = LayerMask.NameToLayer("Player - Swarm");
            _rigidbody = GetComponent<Rigidbody2D>();
            inputReader.Initialize(); //need to manually initialize
            if (metrics) _rigidbody.gravityScale = metrics.gravityScale;
        }

        private void OnEnable()
        {
            HookAddListener();

            inputReader.movePerformedEvent += OnMove;
            inputReader.moveCanceledEvent += OnMove;

            inputReader.jumpStartedEvent += OnJumpStarted;
            inputReader.jumpCanceledEvent += OnJumpCanceled;

            inputReader.dashStartedEvent += OnDashStarted;

            inputReader.noclipPerformedEvent += OnNoclipPerformed;
        }

        private void OnDisable()
        {
            HookRemoveListener();

            inputReader.movePerformedEvent -= OnMove;
            inputReader.moveCanceledEvent -= OnMove;

            inputReader.jumpStartedEvent -= OnJumpStarted;
            inputReader.jumpCanceledEvent -= OnJumpCanceled;

            inputReader.dashStartedEvent -= OnDashStarted;

            inputReader.noclipPerformedEvent -= OnNoclipPerformed;
        }

        public void OnMove(Vector2 mvt)
        {
            // Recover the player's input, clamping it to avoid diagonals directions
            _movementInput = Vector2.zero;
            if (!_noclip)
            {
                if (mvt.x >= 0.2f)
                    _movementInput = Vector2.right;
                else if (mvt.x <= -0.2f)
                    _movementInput = Vector2.left;
            }
            else
                _movementInput = mvt;

            if (_movementInput.y < -0.8f) _isHooked = false;
        }

        // Triggers when the player jumps
        private void OnJumpStarted()
        {
            if ((isGrounded || _isHooked || _canJumpHook) && !_isDashing && !_isPullingBlock)
            {
                // The player jumps using an impulse force
                _rigidbody.AddForce(Vector2.up * metrics.initialJumpForce, ForceMode2D.Impulse);
                _rigidbody.gravityScale = metrics.gravityScale;
                _jumpClock = Time.time;
                _isJumping = true;
                _canJumpHook = false;

                animator.SetTrigger("Jumping");
            }
        }

        // Triggers when the player stops jumping
        private void OnJumpCanceled()
        {
            // The player released the jump button
            _isJumping = false;
        }

        // Triggers when the player dashes
        private void OnDashStarted()
        {
            if (!_isDashing && !_hasDashedInAir && !_isPullingBlock)
            {
                _rigidbody.velocity = Vector2.zero;
                
                _rigidbody.gravityScale = 0f;

                _dashClock = Time.time;
                _isDashing = true;
                inputReader.DisableDash();
                _isHooked = false;

                gameObject.layer = _swarmDashLayer;

                animator.SetTrigger("Dashing");

                StartCoroutine(OverlapStunable());
            }
        }

        // DEBUG
        private void OnNoclipPerformed()
        {
            _rigidbody.gravityScale = (_noclip = !_noclip) ? 0f : metrics.gravityScale;
        }

        public void LockMovement(bool value)
        {
            _canMove = !value;
        }

        #region Hook

        private void HookAddListener()
        {
            if (!hookEvents) return;
            hookEvents.started += OnHookStarted;
            hookEvents.performed += OnHookPerformed;
            hookEvents.ended += OnHookEnded;
            hookEvents.released += OnHookReleased;
        }

        private void HookRemoveListener()
        {
            if (!hookEvents) return;
            hookEvents.started -= OnHookStarted;
            hookEvents.performed -= OnHookPerformed;
            hookEvents.ended -= OnHookEnded;
            hookEvents.released -= OnHookReleased;
        }

        private void OnHookStarted(HookBehaviour behaviour)
        {
            if (!behaviour.isCurrentTarget) return;

            LockMovement(true);

            switch (behaviour)
            {
                case GrappleHookBehaviour grapple:
                    //animator?.SetTrigger(Animator.StringToHash("grapple_start"));
                    break;
                case PullHookBehaviour pull:
                    _rigidbody.velocity = Vector2.zero;
                    IsPullingBlock = true;
                    break;
                case SnatchHookBehaviour snatch:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(behaviour));
            }
        }

        private void OnHookPerformed(HookBehaviour behaviour)
        {
            if (!behaviour.isCurrentTarget) return;

            switch (behaviour)
            {
                case GrappleHookBehaviour grapple:
                    _rigidbody.MovePosition(grapple.nextPosition);
                    break;
                case PullHookBehaviour pull:
                    break;
                case SnatchHookBehaviour snatch:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(behaviour));
            }
        }

        private void OnHookEnded(HookBehaviour behaviour)
        {
            if (!behaviour.isCurrentTarget) return;
            
            switch (behaviour)
            {
                case GrappleHookBehaviour grapple:
                    //animator?.SetTrigger(Animator.StringToHash("grapple_end"));
                    inputReader.EnableJump();
                    _isHooked = true;
                    _canJumpHook = true;
                    _hasDashedInAir = false;
                    animator.SetBool("Is Grounded", isGrounded);
                    _rigidbody.velocity = Vector2.zero;
                    _rigidbody.gravityScale = 0f;
                    break;
                case PullHookBehaviour pull:
                    LockMovement(false);
                    IsPullingBlock = false;
                    break;
                case SnatchHookBehaviour snatch:
                    LockMovement(false);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(behaviour));
            }
        }

        private void OnHookReleased(HookBehaviour behaviour)
        {
            if (!behaviour.isCurrentTarget) return;

            LockMovement(false);
            _isHooked = false;

            switch (behaviour)
            {
                case GrappleHookBehaviour grapple:
                    _rigidbody.gravityScale = metrics.gravityScale;
                    break;
                case PullHookBehaviour pull:
                    IsPullingBlock = false;
                    break;
                case SnatchHookBehaviour snatch:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(behaviour));
            }
        }
        
        #endregion

        private void Update()
        {
            Vector2 vel = Vector2.zero; //useless but necessary for the SmoothDamp
            _smoothMovement = Vector2.SmoothDamp(_smoothMovement, _movementInput, ref vel, _smoothInput);

            // Stops the jump if held for too long
            if (_isJumping && _jumpClock + metrics.maxJumpHold < Time.time)
                _isJumping = false;

            // Stops the dash when its duration is past
            if (_isDashing && _dashClock + metrics.dashDuration < Time.time)
            {
                _rigidbody.velocity = Vector2.zero;
                _rigidbody.gravityScale = metrics.gravityScale;
                _isDashing = false;

                gameObject.layer = _defaultLayer;

                StartCoroutine(DashCooldown());
            }

            RotatePlayerModel(); //don't read this.. or at least don't try to understand it -> it just works
            UpdateStates();
        }

        private void FixedUpdate()
        {
            // remove jump when releasing from hook
            if (_canJumpHook && _rigidbody.velocity.y <= -Mathf.Epsilon)
            {
                _canJumpHook = false;
            }

            // Moves the player horizontally with according speeds while not dashing
            if (!_isDashing && _canMove && !_isPullingBlock)
            {
                if (isGrounded || _isHooked)
                    _rigidbody.velocity = new Vector2(_smoothMovement.x * metrics.horizontalSpeed, _rigidbody.velocity.y);
                else
                    _rigidbody.velocity = new Vector2(_smoothMovement.x * metrics.inAirHorizontalSpeed, _rigidbody.velocity.y);
            }

            // DEBUG
            if (_noclip)
                _rigidbody.velocity = _movementInput * metrics.noclipSpeed;

            // Moves the player upward while holding the jump button
            if (_isJumping)
                _rigidbody.AddForce(Vector2.up * metrics.heldJumpForce, ForceMode2D.Force);

            if (_isDashing)
                _rigidbody.velocity = (IsFacingRight ? Vector2.right : Vector2.left) * metrics.dashForce;
        }

        private void LateUpdate()
        {
            animator.SetFloat("Vertical Velocity", _rigidbody.velocity.y);
            animator.SetFloat("Horizontal Velocity", _rigidbody.velocity.x);
        }

        private void UpdateStates()
        {
            // Limit the dash to one use per air-time
            if (_hasDashedInAir && isGrounded)
                _hasDashedInAir = false;

            // Updates the direction the player is facing
            if (_smoothMovement.x != 0f && !_isPullingBlock && !_isHooking)
                isFacingRight = Mathf.Sign(_smoothMovement.x) == 1f;

            // Updates whether the player is running or not
            if (_smoothMovement.x != 0f && Mathf.Abs(_rigidbody.velocity.x) > 0.01f) _isRunning = true;
            else _isRunning = false;
            
            bool wasGrounded = isGrounded;

            // Updates the grounded state - check if one or both "feet" are on a ground
            isGrounded = Physics2D.Raycast(rightGroundCheck.position, Vector2.down, _groundCheckLength, groundLayer)
                || Physics2D.Raycast(leftGroundCheck.position, Vector2.down, _groundCheckLength, groundLayer);

            // only when reach the ground and not falling
            isGrounded = isGrounded && _rigidbody.velocity.y <= Mathf.Epsilon && _rigidbody.velocity.y >= -Mathf.Epsilon;

            // Updates the grounded state - check if one or both "feet" are on a ground
            isGrounded = Physics2D.Raycast(rightGroundCheck.position, Vector2.down, _groundCheckLength, groundLayer)
                || Physics2D.Raycast(leftGroundCheck.position, Vector2.down, _groundCheckLength, groundLayer);
            
            animator.SetBool("Is Grounded", isGrounded);
            animator.SetBool("Is Facing Right", isFacingRight);
            animator.SetBool("Is Pulling", _isPullingBlock);
            animator.SetBool("Is Hooked", _isHooked);
        }

        // Coroutine re-enabling the dash after it's cooldown
        private System.Collections.IEnumerator DashCooldown()
        {
            onDashStun?.Invoke(null, null);

            yield return new WaitForSeconds(metrics.dashCooldown);

            inputReader.EnableDash();
        }

        private System.Collections.IEnumerator OverlapStunable()
        {
            if (!_rigidbody) yield break;

            int size = 0;
            RaycastHit2D[] hits = new RaycastHit2D[3];

            while (_isDashing)
            {
                size = Physics2D.CapsuleCastNonAlloc(_rigidbody.position, new Vector2(1, 2), CapsuleDirection2D.Vertical, _rigidbody.rotation, _rigidbody.velocity.normalized, hits, 0.05f, dashStunLayer);
                if (size <= 0) yield return null;

                foreach (var hit in hits)
                {
                    if (!hit.collider || !hit.collider.gameObject) continue;
                    LogHandler.SendMessage($"{name} found {hit.collider.name} while dashing", MessageType.Log);
                    onDashStun?.Invoke(hit.collider.gameObject, dashStunData);
                }

                yield return null;
            }
        }

        public void Stun(float duration)
        {
            _rigidbody.velocity = Vector2.zero;

            inputReader.DisableMove();
            inputReader.DisableJump();
            inputReader.DisableDash();
            inputReader.DisableHookInteract();
            inputReader.DisableHookGrapple();
            inputReader.DisableSandSoldier();

            StartCoroutine(Stunned(duration));
            animator.SetTrigger("Stunned");
        }

        // Coroutine for the duration of the stun
        System.Collections.IEnumerator Stunned(float duration)
        {
            yield return new WaitForSeconds(duration);

            inputReader.EnableMove();
            inputReader.EnableJump();
            inputReader.EnableDash();
            inputReader.EnableHookInteract();
            inputReader.EnableHookGrapple();
            inputReader.EnableSandSoldier();
        }

        public void Respawn()
        {
            _isRunning = false;
            _isDashing = false;
            _hasDashedInAir = false;
            _isJumping = false;
            _noclip = false; //DEBUG
            _isHooked = false;
            _isPullingBlock = false;
            _isHooking = false;
            LockMovement(false);

            _jumpClock = 0f;
            _dashClock = 0f;

            _rigidbody.gravityScale = metrics.gravityScale;

            gameObject.layer = _defaultLayer;

            Stun(metrics.respawnStunDuration);
        }

        // Turns the character model around when facing the other direction
        private void RotatePlayerModel()
        {
            Quaternion from = _rotation;
            // Lerps between a given orientation when idle facing left and when running facing left
            // This is used because facing left would normally put the back of the model towards the camera -> not fancy !!
            Quaternion to = (_rigidbody.velocity.x > 2f || _rigidbody.velocity.x < -2f) || _isDashing || _isPullingBlock || _isHooking ?
                    Quaternion.Lerp(isFacingRight ? RightRotation : LeftRotationRunning, isFacingRight ? RightRotation : LeftRotationIdle, 0f)
                    : Quaternion.Lerp(isFacingRight ? RightRotation : LeftRotationIdle, isFacingRight ? RightRotation : LeftRotationRunning, 0f);
            _rotation = Quaternion.Lerp(from, to, Time.deltaTime * _turnSpeed);

            // The previously computed rotation is used only when the player isn't hooked, when he is the animator turns it himself
            if (!_isHooked)
                modelTransform.localRotation = _rotation;
            else
                modelTransform.localRotation = Quaternion.Euler(new Vector3(0f, 89.9f, 0f));
        }

    #if UNITY_EDITOR
        // Displays a bunch of stats while the game is playing
        private void OnDrawGizmosSelected()
        {
            if (_rigidbody == null) return;

            // Styles used to display stats
            GUIStyle redStyle = new GUIStyle();
            GUIStyle greenStyle = new GUIStyle();
            redStyle.normal.textColor = Color.red;
            greenStyle.normal.textColor = Color.green;

            // Displays the ground checks radiuses
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(rightGroundCheck.position, rightGroundCheck.position + (Vector3.down * _groundCheckLength));
            Gizmos.DrawLine(leftGroundCheck.position, leftGroundCheck.position + (Vector3.down * _groundCheckLength));

            // Displays the velocity
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(_rigidbody.position, _rigidbody.position + _rigidbody.velocity);

            // Displays stats on top of the player
            Handles.Label(_rigidbody.position + Vector2.up * 4.2f, "IsPullingBlock : " + _isPullingBlock, _isPullingBlock ? greenStyle : redStyle);
            Handles.Label(_rigidbody.position + Vector2.up * 4.0f, "IsHooked : " + _isHooked, _isHooked ? greenStyle : redStyle);
            Handles.Label(_rigidbody.position + Vector2.up * 3.8f, "IsPullingBlock : " + _isPullingBlock, _isPullingBlock ? greenStyle : redStyle);
            Handles.Label(_rigidbody.position + Vector2.up * 3.6f, "IsJumping : " + _isJumping, _isJumping ? greenStyle : redStyle);
            Handles.Label(_rigidbody.position + Vector2.up * 3.4f, "IsDashing : " + _isDashing, _isDashing ? greenStyle : redStyle);
            Handles.Label(_rigidbody.position + Vector2.up * 3.2f, "HasDashedInAir : " + _hasDashedInAir, _hasDashedInAir ? greenStyle : redStyle);
            Handles.Label(_rigidbody.position + Vector2.up * 2.8f, "IsRunning : " + _isRunning, _isRunning ? greenStyle : redStyle);
            Handles.Label(_rigidbody.position + Vector2.up * 2.6f, "IsFacingRight : " + isFacingRight, isFacingRight ? greenStyle : redStyle);
            Handles.Label(_rigidbody.position + Vector2.up * 2.4f, "isFalling : " + isGrounded, isGrounded ? greenStyle : redStyle);
            Handles.Label(_rigidbody.position + Vector2.up * 2.2f, "Speed : " + _rigidbody?.velocity.magnitude + " m/s", _rigidbody.velocity.magnitude != 0f ? greenStyle : redStyle);
            Handles.Label(_rigidbody.position + Vector2.up * 2f, "NOCLIP (O) : " + _noclip, _noclip ? greenStyle : redStyle);
            Handles.Label(_rigidbody.position + Vector2.up * 1.8f, "" + inputReader);
        }
#endif
    }
    
}
