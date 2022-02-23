﻿using System;
using System.Linq;
using BehaviourTree.Tools;
using Pharaoh.Gameplay.Components;
using Pharaoh.Tools;
using Pharaoh.Tools.Debug;
using UnityEngine;

namespace Pharaoh.AI.Actions
{
    public class CheckTargetInOverlap : ActionNode
    {
        [SerializeField] private Collider[] colliders3D;
        [SerializeField] private Collider2D[] colliders2D;

        private Collider _collider3D;
        private Collider2D _collider2D;

        private DetectionComponent _detection;

        private bool _is2D = false;

        protected override void OnStart()
        {
            if (_detection) return;

            if (!agent.TryGetComponent(out _detection))
            {
                LogHandler.SendMessage($"No detection possible with this agent.", MessageType.Warning);
            }

            if (_collider3D || _collider2D) return;

            if (agent.TryGetComponent(out _collider3D))
            {
                colliders3D = new Collider[8];
            }

            if (agent.TryGetComponent(out _collider2D))
            {
                colliders2D = new Collider2D[8];
                _is2D = true;
            }

            LogHandler.SendMessage($"No collider on this agent.", MessageType.Warning);
        }

        protected override NodeState OnUpdate()
        {
            int size;
            int index = 0;

            if (_is2D)
            {
                size = _collider2D.OverlapNonAlloc(ref colliders2D, _detection.detectionLayer);
                if (colliders2D[0] && colliders2D[0].transform == agent.transform) index++;
            }
            else
            {
                size = _collider3D.OverlapNonAlloc(ref colliders3D, _detection.detectionLayer);
                if (colliders3D[0] && colliders3D[0].transform == agent.transform) index++;
            }

            if (size <= index)
            {
                blackboard.ClearData("target");
                state = NodeState.Running;
                return state;
            }
            
            blackboard.SetData("target", colliders3D[index].transform);
            state = NodeState.Success;
            return state;
        }
    }
}