using System;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    public abstract class RuntimeSet<T> : ScriptableObject
    {
        public HashSet<T> items = new HashSet<T>();

        public void Add(T t)
        {
            if (!items.Contains(t)) items.Add(t);
        }

        public void Remove(T t)
        {
            if (items.Contains(t)) items.Remove(t);
        }

        private void OnDisable()
        {
            items.Clear();
        }
    }
}