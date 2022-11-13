using UnityEngine;

namespace ScriptableObjects.BattleObject.ModelSO
{
    [CreateAssetMenu(menuName = "BattleObject/Model/Mount")]    
    public class MountModelSO : ScriptableObject
    {
        public float muzzleVel;
        public float range;
        public float fireRate;
        public float maxRotVel;
        public float targetingAccuracy;
    }
}