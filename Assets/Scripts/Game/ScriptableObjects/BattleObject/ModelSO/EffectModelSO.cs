using System;
using UnityEngine;

namespace Game.ScriptableObjects.BattleObject.ModelSO
{
    [Serializable]
    [CreateAssetMenu(menuName = "BattleObject/Model/Effect")]
    public class EffectModelSO : ScriptableObject
    {
        [TextArea]
        public string description;

        public float directDamage;
        public float indirectDamage;
        public float indirectDamageDistanceFallOfMultiplier;
        public float indirectDamageRange;
        public float dps;
    }
}