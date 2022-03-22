﻿using System;
using Pharaoh.Gameplay.Components.Movement;
using Pharaoh.Tools.Debug;
using UnityEngine;

namespace Pharaoh.Gameplay
{
    public class GrappleHookBehaviour : HookBehaviour
    {
        [SerializeField, Tooltip("target position the player is going to be at the end")]
        private Transform finalMoveTarget;
        
        private readonly WaitForFixedUpdate _waitForFixedUpdate = new WaitForFixedUpdate();
        private Coroutine _moveToCoroutine;
        
        protected override void OnEnable()
        {
            base.OnEnable();
            _input.CharacterControls.Move.performed += OnMove;
            _input.CharacterControls.Jump.started += OnJump;
            _input.CharacterControls.Dash.started += OnDash;
        }

        protected override void OnDisable()
        {
            _input.CharacterControls.Move.performed -= OnMove;
            _input.CharacterControls.Jump.started -= OnJump;
            _input.CharacterControls.Dash.started -= OnDash;
            base.OnDisable();
        }

        private void FixedUpdate()
        {
            if (!isCurrentTarget || !_hook) return;

            // Cancel grapple when encounter an obstacle 
            Vector2 hookPosition = _hook.transform.position;
            Vector2 direction = (Vector2)transform.position - hookPosition;
            int size = Physics2D.RaycastNonAlloc(hookPosition, direction.normalized, 
                _hits, direction.magnitude, _hook.whatIsObstacle);
            if (size > 0)
            {
                Release();
            }
        }

        private void OnMove(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
        {
            if (!isCurrentTarget) return;

            var axis = _input.CharacterControls.Move.ReadValue<Vector2>();
            if (axis.y >= -0.8f) return;

            Release();
        }

        private void OnJump(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
        {
            if (!isCurrentTarget) return;
            Release();
        }

        private void OnDash(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
        {
            if (!isCurrentTarget) return;
            Release();
        }

        protected override void Release()
        {
            base.Release();
            if (_moveToCoroutine != null) StopCoroutine(_moveToCoroutine);
        }

        public override void Interact(HookCapacity hook, GameObject target)
        {
            base.Interact(hook, target);
            if (!isCurrentTarget) return;

            if (hookIndicator) hookIndicator.SetActive(false);
            _moveToCoroutine = StartCoroutine(Grapple());
        }

        private System.Collections.IEnumerator Grapple()
        {
            if (!_hook) yield break;

            float speed = _hook.grappleData.speed;
            AnimationCurve curve = _hook.grappleData.curve;
            Vector2 startPosition = _hook.transform.position;

            float maxDistance = Vector2.Distance(startPosition, finalMoveTarget.position);
            float timeToTravel = maxDistance / speed;
            float currentTime = 0f;
            
            while (currentTime < timeToTravel)
            {
                nextPosition =  Vector2.Lerp(startPosition, finalMoveTarget.position, curve.Evaluate(currentTime / timeToTravel));
                currentTime = Mathf.MoveTowards(currentTime, timeToTravel, Time.fixedDeltaTime * speed);
                Perform();

                yield return _waitForFixedUpdate;
            }
            
            End();
        }
    }
}