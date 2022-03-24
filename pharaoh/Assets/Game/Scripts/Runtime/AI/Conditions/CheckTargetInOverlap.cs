﻿using System;
using System.Linq;
using BehaviourTree.Tools;
using Pharaoh.Gameplay.Components;
using Pharaoh.Tools;
using Pharaoh.Tools.Debug;
using UnityEngine;
using MessageType = Pharaoh.Tools.Debug.MessageType;

namespace Pharaoh.AI.Actions
{
    public class CheckTargetInOverlap : ActionNode
    {
        private DetectionComponent _detection = null;
        [SerializeField] private DetectionData mask;

        protected override void OnStart()
        {
            if (_detection) return;

            if (agent.TryGetComponent(out _detection)) return;

            LogHandler.SendMessage($"[{agent.name}] Can't detect enemies", MessageType.Warning);
        }

        protected override NodeState OnUpdate()
        {
            if (!_detection || !mask || !_detection.hasDetectionCollider) return NodeState.Failure;
            
            var target = _detection.GetGameObjectWithLayer(mask);
            if (target == null)
            {
                blackboard.ClearData("target");
                return NodeState.Failure;
            }
            
            blackboard.SetData("target", target.transform);
            return NodeState.Success;
        }
    }
}