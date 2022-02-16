﻿
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Pharaoh.Gameplay.Components.Events
{
    [Serializable]
    public abstract class AbstractGameEventListener<T, E, UER> : MonoBehaviour, IGameEventListener<T> 
        where E : AbstractGameEvent<T> 
        where UER : UnityEvent<T>
    {
        [field: SerializeField] public E gameEvent { get; private set; } 
        [field: SerializeField] public UER response { get; private set; } 

        public void OnEnable() 
        {
            gameEvent?.RegisterListener(this);
        }

        public void OnDisable() 
        {
            gameEvent?.UnregisterListener(this);
        }

        public void OnEventRaised(T item) 
        {
            response?.Invoke(item);
        }
    }

    [Serializable]
    public abstract class AbstractGameEventListener<T0, T1, E, UER> : MonoBehaviour, IGameEventListener<T0, T1> 
        where E : AbstractGameEvent<T0, T1> 
        where UER : UnityEvent<T0, T1>
    {
        [field: SerializeField] public E gameEvent { get; private set; } 
        [field: SerializeField] public UER response { get; private set; } 

        public void OnEnable() 
        {
            gameEvent?.RegisterListener(this);
        }

        public void OnDisable() 
        {
            gameEvent?.UnregisterListener(this);
        }

        public void OnEventRaised(T0 item1, T1 item2) 
        {
            response?.Invoke(item1, item2);
        }
    }

    [Serializable]
    public abstract class AbstractGameEventListener<T0, T1, T2, E, UER> : MonoBehaviour, IGameEventListener<T0, T1, T2> 
        where E : AbstractGameEvent<T0, T1, T2> 
        where UER : UnityEvent<T0, T1, T2>
    {
        [field: SerializeField] public E gameEvent { get; private set; } 
        [field: SerializeField] public UER response { get; private set; } 

        public void OnEnable() 
        {
            gameEvent?.RegisterListener(this);
        }

        public void OnDisable() 
        {
            gameEvent?.UnregisterListener(this);
        }

        public void OnEventRaised(T0 item1, T1 item2, T2 item3) 
        {
            response?.Invoke(item1, item2, item3);
        }
    }

}