using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Util;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Enums/BodyType")]
    public class BodyType : ScriptableObject, IEnum
    {
        [TextArea]
        public string description;
        public List<ArmorType> armorTypes;
        public BodyModel bodyModel;
    }
}