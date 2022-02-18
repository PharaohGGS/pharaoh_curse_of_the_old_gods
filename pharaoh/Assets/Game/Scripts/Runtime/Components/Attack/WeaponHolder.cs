﻿using UnityEngine;

namespace Pharaoh.Gameplay.Components
{
    public class WeaponHolder : MonoBehaviour
    {
        public DamagerData data;
        public Weapon weapon { get; private set; }

        private void Awake()
        {
            if (data == null) return;

            weapon = GameObject.Instantiate(data.prefab, transform.position, transform.rotation, transform) as Weapon;
        }
    }
}