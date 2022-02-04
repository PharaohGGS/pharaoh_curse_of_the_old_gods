﻿using UnityEngine;

namespace Pharaoh.Tools.BehaviourTree.ScriptableObjects
{
    public abstract class DecoratorNode : Node
    {
        [HideInInspector] public Node child;
    }
}