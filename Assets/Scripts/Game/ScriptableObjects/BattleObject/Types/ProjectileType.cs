using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Util;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Enums/ProjectileType")]
    public class ProjectileType : ScriptableObject, IEnum
    {
        [TextArea]
        public string description;
        public List<DamageType> damageTypes;
        public List<ProjectileCurveType> projectileCurveTypes;
        public List<ArmorType> weakAgainst;
        public List<ArmorType> strongAgainst;
        public ProjectileModel projectileModel;
    }
}