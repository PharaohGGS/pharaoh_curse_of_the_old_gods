﻿using System.Linq;
using BehaviourTree.Tools;
using Pharaoh.Gameplay.Components;
using Pharaoh.Tools.Debug;
using UnityEngine;

namespace Pharaoh.AI.Actions
{
    public class TaskAttack : ActionNode
    {
        [SerializeField] protected GearType gearType;

        protected HealthComponent _healthComponent;

        protected AttackComponent _attack = null;
        
        protected override void OnStart()
        {
            if (_attack) return;

            if (!agent.TryGetComponent(out _attack))
            {
                LogHandler.SendMessage($"[{agent.name}] Can't _attack enemies", MessageType.Warning);
            }
        }

        protected override NodeState OnUpdate()
        {
            if (!_attack || gearType == GearType.Null) return NodeState.Failure;
            
            if (!_attack.TryGetHolder(gearType, out var holder))
            {
                LogHandler.SendMessage($"{agent.name} don't have a weapon of this type.", MessageType.Error);
                return NodeState.Failure;
            }

            var gearData = holder.gear.GetBaseData();

            if (!gearData.canAttack)
            {
                LogHandler.SendMessage($"{agent.name} can't attack with his weapon", MessageType.Warning);
                return NodeState.Failure;
            }

            if (!blackboard.TryGetData("target", out Transform t))
            {
                LogHandler.SendMessage($"{agent.name} doesn't have a target to attack.", MessageType.Error);
                return NodeState.Failure;
            }

            state = NodeState.Running;

            if (t != _attack.target && t.TryGetComponent(out HealthComponent healthComponent))
            {
                _attack.target = t;

                if (_healthComponent != healthComponent)
                {
                    _healthComponent?.onDeath?.RemoveListener(OnTargetDeath);
                    _healthComponent = healthComponent;
                    _healthComponent?.onDeath?.AddListener(OnTargetDeath);
                }
            }
            
            _attack.Attack(holder);
            var rate = holder.gear.isThrown && gearData is MeleeGearData meleeGearData
                ? meleeGearData.throwablePickingTime : gearData.rate;

            blackboard.SetData("isWaiting", true);
            blackboard.SetData("waitTime", rate);

            return state;
        }

        protected void OnTargetDeath(HealthComponent healthComponent)
        {
            blackboard.ClearData("target");
            _attack.target = null;
        }
    }
}