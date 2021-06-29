using System;
using UnityEngine;

namespace EdwinGameDev.Events
{
    
    public class ScriptableEvent<T> : ScriptableObject
    {
        private event Action<T> OnTriggered;

        public void Subscribe(Action<T> action)
        {
            OnTriggered += action;
        }

        public void UnSubscribe(Action<T> action)
        {
            OnTriggered -= action;
        }

        public void Notify(T value)
        {
            OnTriggered?.Invoke(value);
        }
    }
}