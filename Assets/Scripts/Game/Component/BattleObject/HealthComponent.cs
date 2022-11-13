using System;
using Component.Simulation;
using DefaultNamespace;
using Manager;
using UnityEngine;

namespace Component.BattleObject
{
    public class HealthComponent : MonoBehaviour
    {
        private BattleObjectSettingsModel battleObject;
        
        private float maxHealth;
        private float minHealth;
        private float currentHealth;

        public void OnSimulationStart()
        {
            // maxHealth = battleObject.maxHealth;
            // currentHealth = maxHealth;
        }

        public void ChangeHealth(float amount)
        {
            currentHealth = Mathf.Clamp(currentHealth - amount, minHealth, maxHealth);
        }

        public float GetCurrentHealth()
        {
            return currentHealth;
        }

        public void SetMaxHealth(float maxHealth)
        {
            this.maxHealth = maxHealth;
        }
    }
}