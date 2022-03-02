﻿using System;
using BehaviourTree.Tools;
using Pharaoh.Gameplay.Components;
using Pharaoh.Tools.Debug;

namespace Pharaoh.AI.Actions
{
    public abstract class CheckHoldingWeapon<T> : ActionNode where T : DamagerData
    {
        private AttackComponent _attack;

        protected override void OnStart()
        {
            if (_attack) return;

            if (agent.TryGetComponent(out _attack)) return;

            LogHandler.SendMessage($"[{agent.name}] Can't _attack enemies", MessageType.Warning);
        }

        protected override NodeState OnUpdate()
        {
            if (!_attack)
            {
                state = NodeState.Failure;
                return state;
            }

            if (!_attack.TryGetHolder<T>(out var holder))
            {
                state = NodeState.Failure;
                return state;
            }

            if (holder.Gear.transform.parent)
            {
                state = NodeState.Success;
            }
            else
            {
                state = NodeState.Failure;

                if (holder.Gear.isThrown && holder.Gear.isGrounded)
                {
                    blackboard.SetData("target", holder.Gear.transform);
                }
            }

            return state;
        }
    }
}