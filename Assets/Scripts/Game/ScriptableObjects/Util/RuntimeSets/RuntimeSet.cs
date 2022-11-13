using System;
using System.Collections.Generic;
using RoboRyanTron.Unite2017.Events;
using UnityEngine;

namespace ScriptableObjects.RuntimeSets
{
    public abstract class RuntimeSet<T> : ScriptableObject
    {
        public List<T> items = new List<T>();
        public Action<T> addEvent;
        public Action<T> removeEvent;

        public void Add(T t)
        {
            if (!items.Contains(t))
            {
                items.Add(t);
                addEvent?.Invoke(t);
            }
        }

        public void Remove(T t)
        {
            if (items.Contains(t))
            {
                items.Remove(t);
                removeEvent?.Invoke(t);
            }
        }
        
    }
}