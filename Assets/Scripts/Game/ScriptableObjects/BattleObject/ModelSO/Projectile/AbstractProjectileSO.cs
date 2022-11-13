using System;
using UnityEngine;

namespace ScriptableObjects.BattleObject
{
    [Serializable]
    public abstract class AbstractProjectileSO : ScriptableObject
    {
        [TextArea]
        public string description;
        public float range;
        public float maxVel;
        public float accuracy;
        public bool targetFollowing;
    }
}