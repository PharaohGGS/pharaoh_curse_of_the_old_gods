﻿using Pharaoh.Tools;
using Pharaoh.Tools.Debug;
using UnityEngine;

namespace Pharaoh.Gameplay.Components
{
    public class AiDetection : Detection<CircleCollider2D>
    {
        [SerializeField, Tooltip("TargetFinder FOV"), Range(1f, 360f)]
        private float overlappingFov = 270f;

        protected override void FixedUpdate()
        {
            if (!canDetect) return;
            base.FixedUpdate();

            // if colliders are behind an obstacle, clear it
            for (int i = 0; i < _colliders.Length; i++)
            {
                if (!_colliders[i]) continue;

                Vector2 center = transform.TransformPoint(detectionCollider.offset);
                Vector2 direction = (Vector2)_colliders[i].transform.position - center;
                float distance = direction.magnitude - Mathf.Epsilon;

                var isFacingRight = Vector2.Dot(transform.right, Vector2.right) > 0.0f;
                if (Vector2.Angle(transform.right * (isFacingRight ? 1 : -1), direction.normalized) < overlappingFov / 2) continue;
                if (!Physics2D.Raycast(center, direction.normalized, distance, whatIsObstacle)) continue;

                _colliders[i] = null;
            }
        }

        public bool TryGetByLayerMask(LayerMask layer, out GameObject obj)
        {
            obj = GetByLayerMask(layer);
            return obj != null;
        }
        
        public GameObject GetByLayerMask(LayerMask layer)
        {
            if (overlappedCount <= 0) return null;

            // check if the mask as multiple layers
            var layerIndexes = layer.GetLayerIndexes();
            if (layerIndexes.Length > 1)
            {
                LogHandler.SendMessage($"Too much layers for just one gameObject", MessageType.Error);
                return null;
            }

            foreach (var coll in _colliders)
            {
                if (!coll || !coll.gameObject.activeInHierarchy || !coll.gameObject.HasLayer(layer)) continue;
                return coll.gameObject;
            }

            return null;
        }

        public bool OverlapPoint(Vector2 point) => detectionCollider && detectionCollider.OverlapPoint(point);


        #region Editor Debug

#if UNITY_EDITOR

        private void OnDrawGizmosSelected()
        {
            Vector2 DirectionFromAngle(float eulerY, float degreeAngle)
            {
                degreeAngle += eulerY;
                return new Vector2(Mathf.Sin(degreeAngle * Mathf.Deg2Rad), Mathf.Cos(degreeAngle * Mathf.Deg2Rad));
            }

            if (!TryGetComponent(out Collider2D coll)) return;

            // Draws a disc around the player displaying the targeting range
            UnityEditor.Handles.color = new Color(1f, 0.7531517f, 0f, 1f);
            UnityEditor.Handles.DrawWireDisc(transform.position + (Vector3)coll.offset, Vector3.forward, detectionCollider.radius);

            if (!detectionCollider) return;

            var isFacingRight = Vector2.Dot(transform.right, Vector2.right) > 0.0f;
            float eulerY = -transform.eulerAngles.z + 90f * (isFacingRight ? 1f : -1f);
            Vector3 angle0 = DirectionFromAngle(eulerY, -overlappingFov / 2);
            Vector3 angle1 = DirectionFromAngle(eulerY, overlappingFov / 2);

            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position + (Vector3)coll.offset, transform.position + (Vector3)coll.offset + angle0 * detectionCollider.radius);
            Gizmos.DrawLine(transform.position + (Vector3)coll.offset, transform.position + (Vector3)coll.offset + angle1 * detectionCollider.radius);

            if (_colliders is not { Length: > 0 }) return;

            Gizmos.color = Color.green;

            foreach (var overlap in _colliders)
            {
                if (overlap == null) continue;
                Gizmos.DrawLine(transform.position + (Vector3)coll.offset, overlap.transform.position);
            }
        }
#endif

        #endregion
    }
}