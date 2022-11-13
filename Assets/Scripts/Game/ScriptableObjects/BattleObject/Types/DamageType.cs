using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Util;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Enums/DamageType")]
    public class DamageType : ScriptableObject, IEnum
    {
        [TextArea]
        public string description = "Explosion, direct-impact, ricochet";
        public List<ArmorType> armorResistanceType;
        public DamageModel damageModel;
    }
}