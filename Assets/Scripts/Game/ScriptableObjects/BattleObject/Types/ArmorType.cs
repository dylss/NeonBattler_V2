using DefaultNamespace;
using UnityEngine;
using Util;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Enums/ArmorType")]
    public class ArmorType : ScriptableObject, IEnum
    {
        public ArmorTypeModel armorTypeModel;
        [TextArea]
        public string description;

        public Material material;
        public float damageResistanceMultiplier;//remove
    }
}