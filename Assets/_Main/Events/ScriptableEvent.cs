using System;
using UnityEngine;

namespace EdwinGameDev.Events
{
    
    public class ScriptableEvent<T> : ScriptableObject
    {
        private event Action<T> OnTriggered;

        public void Attach(Action<T> action)
        {
            OnTriggered += action;
        }

        public void Dettach(Action<T> action)
        {
            OnTriggered -= action;
        }

        public void Trigger(T value)
        {
            OnTriggered?.Invoke(value);
        }
    }
}