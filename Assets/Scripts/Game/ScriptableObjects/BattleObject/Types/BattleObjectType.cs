using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Util;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Enums/BattleObjectType")]
    public class BattleObjectType : ScriptableObject, IEnum
    {
        public List<BodyType> bodyTypes;
        public List<BarrelType> barrelTypes;
        public List<ProjectileType> projectileTypes;
        
        // [TextArea]
        // public string description;
        //
        // public ArmorType armorType;
        // public BarrelType barrelType;
        // public BodyType bodyType;
        // public DamageType damageType;
        // public MountType mountType;
        // public ProjectileType projectileType;
        // public ProjectileCurveType projectileCurveType;

        public BattleObjectModel battleObjectModel;
    }
}