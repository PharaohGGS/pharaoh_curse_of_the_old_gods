﻿using System;
using Pharaoh.Gameplay.Components;
using Pharaoh.Tools.Debug;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using MessageType = Pharaoh.Tools.Debug.MessageType;

namespace Pharaoh.Gameplay
{
    [RequireComponent(typeof(PlayerMovement))]
    public class GrabTargeting : Targeting
    {
        [Header("Grab")] 
        
        [SerializeField] private float offsetGrab;
        [SerializeField] private float grabSpeed;

        private PlayerInput _playerInput;
        private PlayerMovement _playerMovement;

        private bool _hasEndGrabbing = false;
        private Rigidbody2D _targetRigidbody;

        private Coroutine _grabbingMove;
        private readonly WaitForFixedUpdate _waitForFixedUpdate = new WaitForFixedUpdate();

        [Header("Events")]

        public UnityEvent onGrab = new UnityEvent();
        public UnityEvent onUnGrab = new UnityEvent();

        protected override void Awake()
        {
            base.Awake();
            _playerInput = new PlayerInput();
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void OnEnable()
        {
            _playerInput.Enable();
            _playerInput.CharacterActions.Grab.performed += OnGrab;
        }

        private void OnDisable()
        {
            _playerInput.CharacterActions.Grab.performed -= OnGrab;
            _playerInput.Disable();
        }

        private void Update()
        {
            if (!_hasEndGrabbing && _currentTarget) return;
            SearchTargets();
        }

        #region Editor Debug

        private void OnDrawGizmos()
        {
            if (!_playerMovement) return;

            // Draws the best target to the right (red if not the faced direction)
            Gizmos.color = _playerMovement.isFacingRight
                ? new Color(.5f, 0.7531517f, 0f, 1f)
                : new Color(.5f, 0.7531517f, 0f, 0.1f);
            if (_bestTargetRight != null)
                Gizmos.DrawLine(transform.position, _bestTargetRight.transform.position);

            // Draws the best target to the left (red if not the faced direction)
            Gizmos.color = !_playerMovement.isFacingRight
                ? new Color(.5f, 0.7531517f, 0f, 1f)
                : new Color(.5f, 0.7531517f, 0f, 0.1f);
            if (_bestTargetLeft != null)
                Gizmos.DrawLine(transform.position, _bestTargetLeft.transform.position);
        }

        private void OnDrawGizmosSelected()
        {
            // Draws a disc around the player displaying the targeting range
            Handles.color = new Color(.5f, 0.7531517f, 0f, 1f);
            Handles.DrawWireDisc(transform.position, Vector3.forward, overlapingRadius);
        }

        #endregion

        private void OnGrab(InputAction.CallbackContext obj)
        {
            if (!_playerMovement.isGrounded) return;
            // unhook the current grabbed object if there is one
            if (_currentTarget) UnGrab();
            // hook the nearest grabbable objects if there is one
            if (_bestTargetLeft || _bestTargetRight) Grab();
        }

        private void UnGrab()
        {
            LogHandler.SendMessage($"ungrabbing {_currentTarget.name}", MessageType.Log);
            if (_grabbingMove != null) StopCoroutine(_grabbingMove);

            _currentTarget = null;
            _hasEndGrabbing = false;

            if (_targetRigidbody)
            {
                //_targetRigidbody.velocity = Vector2.zero;
                _targetRigidbody.bodyType = RigidbodyType2D.Dynamic;
                _targetRigidbody = null;
            }
            
            onUnGrab?.Invoke();
        }

        private void Grab()
        {
            _currentTarget = null;

            if (!_playerMovement.isFacingRight)
            {
                _currentTarget = _bestTargetRight && !_bestTargetLeft
                    ? _bestTargetRight : _bestTargetLeft;
            }
            else
            {
                _currentTarget = _bestTargetLeft && !_bestTargetRight
                    ? _bestTargetLeft : _bestTargetRight;
            }

            if (!_currentTarget) return;

            var gear = _currentTarget.TryGetComponent(out Gear w) 
                ? w : _currentTarget.GetComponentInParent<Gear>();

            if (!gear || !gear.TryGetData(out DefenseGearData defenseGearData)) return;

            gear.transform.parent = null;
            _targetRigidbody = gear.rb2D;
            _targetRigidbody.velocity = Vector2.zero;
            _targetRigidbody.bodyType = RigidbodyType2D.Kinematic;

            LogHandler.SendMessage($"grabbing {_currentTarget.name}", MessageType.Log);

            _grabbingMove = StartCoroutine(GrabbingMove());
            onGrab?.Invoke();
        }

        private System.Collections.IEnumerator GrabbingMove()
        {
            if (!_targetRigidbody) yield break;

            while (Mathf.Abs(transform.position.x - _targetRigidbody.position.x) > offsetGrab)
            {
                _hasEndGrabbing = false;
                Vector2 direction = (Vector2)transform.position - _targetRigidbody.position;
                float distance = Vector2.Distance(transform.position, _targetRigidbody.position);
                var hit2Ds = Physics2D.RaycastAll(_targetRigidbody.position, direction, distance, whatIsObstacle);

                if (hit2Ds.Length > 0) UnGrab();

                _targetRigidbody.MovePosition(_targetRigidbody.position + direction.normalized * (grabSpeed * Time.fixedDeltaTime));
                yield return _waitForFixedUpdate;
            }

            _hasEndGrabbing = true;
            UnGrab();
        }
    }
}