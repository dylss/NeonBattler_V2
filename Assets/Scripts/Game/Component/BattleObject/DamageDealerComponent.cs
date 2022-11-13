using System;
using Controller;
using UnityEngine;

namespace Component.BattleObject
{
    [RequireComponent(typeof(ProjectileModelController))]
    public class DamageDealerComponent : MonoBehaviour
    {
        public ProjectileModelController projectile;
        
        // public event Action<DamageDealerComponent> onCollisionAction;

        // public void OnCollision(DamageDealerComponent damageDealer)
        // {
        //     if (damageDealer == null)
        //         return;
        //     
        //     onCollisionAction?.Invoke(damageDealer);
        // }

        // public void OnCollisionEnter(Collision other)
        // {
        //     DamageableComponent damageableC = other.gameObject.GetComponent<DamageableComponent>();
        //     damageableC.TakeDamage(this);
        // }
    }
}