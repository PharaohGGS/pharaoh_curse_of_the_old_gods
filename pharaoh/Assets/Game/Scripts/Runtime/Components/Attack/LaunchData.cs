﻿using UnityEngine;

namespace Pharaoh.Gameplay.Components
{
    /// <summary>
    /// https://github.com/SebLague/Kinematic-Equation-Problems/blob/master/Kinematics%20problem%2002/Assets/Scripts/BallLauncher.cs
    /// </summary>
    /// <returns></returns>
    public struct LaunchData
    {
        public readonly Vector3 initialVelocity;
        public readonly float timeToTarget;

        public LaunchData(Vector3 initialVelocity, float timeToTarget)
        {
            this.initialVelocity = initialVelocity;
            this.timeToTarget = timeToTarget;
        }

        public static LaunchData Calculate(float gravity, float height, Vector3 target, Vector3 position)
        {
            float g = gravity * -2;

            Vector3 offset = target - position;
            float time = Mathf.Sqrt(-2 * height / (g * 2)) +
                         Mathf.Sqrt(2 * (offset.y - height) / g);

            Vector3 vy = Vector3.up * Mathf.Sqrt(-2 * g * height);
            Vector3 vxz = new Vector3(offset.x, 0, offset.z) / time;

            return new LaunchData(vxz + vy * -Mathf.Sign(g), time);
        }
    }
}