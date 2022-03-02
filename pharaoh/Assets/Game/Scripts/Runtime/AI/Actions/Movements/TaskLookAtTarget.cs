﻿using BehaviourTree.Tools;
using Pharaoh.Gameplay.Components;
using Pharaoh.Tools;
using Pharaoh.Tools.Debug;
using UnityEngine;

namespace Pharaoh.AI.Actions
{
    public class TaskLookAtTarget : ActionNode
    {
        protected override NodeState OnUpdate()
        {
            if (blackboard.TryGetData("target", out Transform t))
            {
                agent.transform.LookAt2D(t.position);
            }

            state = NodeState.Running;
            return state;
        }
    }
}