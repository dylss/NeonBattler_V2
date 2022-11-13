using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

namespace DefaultNamespace
{
    [System.Serializable]
    public class MountModel
    {
        public List<MountUpgradeModel> mountUpgrades;
        
        public float range;
        public float fireRate;
        public float maxRotVel;
        public float targetingAccuracy;
    }
}