using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Util;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Enums/MountType")]
    public class MountType : ScriptableObject, IEnum
    {
        [TextArea]
        public string description;
        public List<BarrelType> placeableBarrels;
        public MountModel mountModel;
    }
}