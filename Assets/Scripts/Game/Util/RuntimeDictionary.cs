using System.Collections.Generic;
using Model;
using UnityEngine;

namespace Util
{
    public abstract class RuntimeDictionary<T, S> : ScriptableObject
    {
        public Dictionary<T, S> dictionary = new Dictionary<T, S>();

        public void Add(T t, S s)
        {
            if (!dictionary.ContainsValue(s)) dictionary.Add(t, s);
        }

        public void Remove(T t, S s)
        {
            if (dictionary.ContainsValue(s)) dictionary.Remove(t);
        }
    }
}