using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Util;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Enums/BarrelType")]
    public class BarrelType : ScriptableObject, IEnum
    {
        public BarrelModel barrelModel;
        [TextArea]
        public string description;
        public List<ProjectileType> shootableProjectiles;
    }
}