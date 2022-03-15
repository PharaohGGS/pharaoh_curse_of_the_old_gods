﻿using System.Collections.Generic;
using UnityEngine;

namespace Pharaoh.Gameplay.Components
{
    public class MovementComponent : MonoBehaviour
    {
        [field: SerializeField, Range(1f, 100f)] public float moveSpeed { get; private set; } = 5;
        [field: SerializeField, Range(0.01f, 100.0f)] public float closeDistance { get; private set; } = 0.01f;
        [field: SerializeField, Range(1f, 100f)] public float fleeDistance { get; private set; } = 2;
        [field: SerializeField, Range(1f, 100f)] public float timeBetweenWaypoints { get; private set; } = 2;
        [field: SerializeField] public List<Transform> waypoints { get; private set; } = new List<Transform>();
    }
}