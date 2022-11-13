using System;
using DefaultNamespace;
using ScriptableObjects;
using UnityEngine;

namespace Component.BattleObject
{
    [RequireComponent(typeof(HealthComponent))]
    public class DamageableComponent : MonoBehaviour
    {
        public HealthComponent healthC;
        // public ArmorComponent armorC;

        // public void TakeDamage(DamageDealerComponent damageDealer)
        // {
        //     float damage = damageDealer.projectile.Damage;
        //     if (TryGetComponent(out ArmorComponent armorC))
        //     {
        //         damage = armorC.CalculateDamageThroughArmorResistance(damageDealer);
        //     }
        //     healthC.ChangeHealth(healthC.GetCurrentHealth() - damage);
        // }
    }
}