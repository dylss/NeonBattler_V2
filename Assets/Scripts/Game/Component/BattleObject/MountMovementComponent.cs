using System;
using Component.BattleObject;
using DefaultNamespace;
using UnityEngine;

namespace Game.Component.BattleObject
{
    [RequireComponent(typeof(TargetAcquisitionComponent))]
    public class MountMovementComponent : MonoBehaviour
    {
        public BattleObjectModel boModel;

        [SerializeField]
        private TargetAcquisitionComponent targetComponent;
        private void Awake()
        {
            
        }

        public void RotateHorizontally()
        {
            
        }

        public void RotateVertically()
        {
            
        }
    }
}