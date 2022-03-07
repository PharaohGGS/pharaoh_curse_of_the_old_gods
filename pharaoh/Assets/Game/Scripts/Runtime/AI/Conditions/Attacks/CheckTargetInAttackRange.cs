﻿using System;
using BehaviourTree.Tools;
using Pharaoh.Gameplay.Components;
using Pharaoh.Tools.Debug;
using UnityEngine;

namespace Pharaoh.AI.Actions
{
    public class CheckTargetInAttackRange : ActionNode
    {
        [SerializeField] private GearData gearData;

        private AttackComponent _attack;

        protected override void OnStart()
        {
            if (_attack) return;

            if (agent.TryGetComponent(out _attack)) return;

            LogHandler.SendMessage($"[{agent.name}] Can't _attack enemies", MessageType.Warning);
        }

        protected override NodeState OnUpdate()
        {
            if (!_attack || !gearData || !_attack.TryGetHolder(gearData, out var holder) || 
                !blackboard.TryGetData("target", out Transform t))
            {
                return NodeState.Failure;
            }

            var distance = Vector3.Distance(agent.transform.position, t.position);
            var data = holder.gear ? holder.gear.GetBaseData() : null;
            if (!data || distance > data.range)
            {
                return state;
            }

            blackboard.SetData("waitTime", data.rate);
            return NodeState.Success; 
        }
    }
}