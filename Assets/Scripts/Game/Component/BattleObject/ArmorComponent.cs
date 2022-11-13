using DefaultNamespace;
using ScriptableObjects;
using UnityEngine;

namespace Component.BattleObject
{
    public class ArmorComponent : MonoBehaviour
    {
        public BattleObjectSettingsModel battleObject;
        public float strongVersusMultiplier;
        public float weakVersusMultiplier;

        // public float CalculateDamageThroughArmorResistance(DamageDealerComponent damageDealer)
        // {
        //     ProjectileType projectileType = damageDealer.projectile.projectileModel.projectileType;
        //     float initDamage = damageDealer.projectile.Damage;
        //     float damageThroughResistance = initDamage / SuppliedArmorResistance(projectileType);
        //     
        //     return damageThroughResistance;
        // }
        
        // public float SuppliedArmorResistance(ProjectileType projectileType)
        // {
        //     float resistance = battleObject.Armor.damageResistanceMultiplier;
        //     if (projectileType.strongAgainst.Contains(battleObject.Armor))
        //     {
        //         resistance *= strongVersusMultiplier;
        //     }
        //     else if (projectileType.weakAgainst.Contains(battleObject.Armor))
        //     {
        //         resistance *= weakVersusMultiplier;
        //     }
        //     
        //     //If not strong or weak than dont use the additional multiplier
        //     return resistance;
        // }
    }
}