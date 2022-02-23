using System;
using BehaviourTree.Tools;
using UnityEngine;

namespace BehaviourTree.Runtime.Composites
{
    /// <summary>
    /// Fail when all of the child is failing
    /// Success when first success encounter
    /// Running when first running encounter
    /// </summary>
    public class SelectorNode : CompositeNode
    {
        protected override NodeState OnUpdate()
        {
            foreach (var child in children)
            {
                switch (child.Evaluate())
                {
                    case NodeState.Success:
                        state = NodeState.Success;
                        return state;
                    case NodeState.Running:
                        state = NodeState.Running;
                        return state;
                    case NodeState.Failure:
                        continue;
                    default:
                        continue;
                }
            }

            state = NodeState.Failure;
            return state;
        }
    }

}
