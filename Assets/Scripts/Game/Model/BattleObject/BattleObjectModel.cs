using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

namespace DefaultNamespace
{
    [System.Serializable]
    public class BattleObjectModel
    {
        [Header("Health")]
        public float maxHealth;

        [Header("Armor")]
        public float armor;
        public float armorResistanceMultiplier;
        
        [Header("Damage")]
        public float directDamage;
        public float indirectDamage;
        public float indirectDamageDistanceFallOfMultiplier;
        public float indirectDamageRange;
        public float dps;
        

        [Header("Projectile")] 
        public float maxVel;
        public float accuracy;
        public bool targetFollowing;
        
        [Header("Body")]
        public float maxLinearVel;
        public float maxRotVelBody;
        
        [Header("Mount")]
        public float range;
        public float fireRate;
        public float maxRotVelMount;
        public float targetingAccuracy;
        public float muzzleVel;
        
        // [Header("Health")]
        // [_ReadOnly] public float maxHealth;
        //
        // [Header("Armor")]
        // [_ReadOnly] public float armor;
        // [_ReadOnly] public float armorResistanceMultiplier;
        //
        // [Header("Damage")]
        // [_ReadOnly] public float directDamage;
        // [_ReadOnly] public float indirectDamage;
        // [_ReadOnly] public float indirectDamageDistanceFallOfMultiplier;
        // [_ReadOnly] public float indirectDamageRange;
        //
        // [Header("Projectile")] 
        // [_ReadOnly] public float maxVel;
        // [_ReadOnly] public float accuracy;
        // [_ReadOnly] public bool targetFollowing;
        //
        // [Header("Body")]
        // [_ReadOnly] public float maxLinearVel;
        // [_ReadOnly] public float maxRotVelBody;
        //
        // [Header("Mount")]
        // [_ReadOnly] public float range;
        // [_ReadOnly] public float fireRate;
        // [_ReadOnly] public float maxRotVelMount;
        // [_ReadOnly] public float targetingAccuracy;
        // [_ReadOnly] public float muzzleVel;
    }
}