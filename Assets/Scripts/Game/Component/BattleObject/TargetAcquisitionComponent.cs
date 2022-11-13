using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using Game.Component.BattleObject;
using propertyDrawerCustom;
using ScriptableObjects;
using UnityEngine;

namespace Component.BattleObject
{
    public class TargetAcquisitionComponent : MonoBehaviour
    {
        [SerializeField] private BattleObjectController boController;
        [SerializeField] private BattleObjectSimulationController boSimController;
        [SerializeField] private GameObject currentTarget;

        public GameObject CurrentTarget
        {
            get { return currentTarget; }
            private set { currentTarget = value; }
        }
        
        public bool IsCurrentTargetWithinRange
        {
            get
            {
                if (currentTarget == null) return true;
                return Vector3.Distance(currentTarget.GetComponentInChildren<HitPointComponent>().hitPoint.transform.position,transform.position) <= boController.BoModel.range;
            }
        }

        public List<GameObject> EnemiesInRange
        {
            get
            {
                return GetTargetsWithinRange(transform);
            }
        }
        
        private void Update()
        {
            if(boSimController == null || boSimController.AliveEnemies == null) return;
            if(boSimController.AliveEnemies.Count == 0) return;
            
            //If not set yet, than get closest target
            if (currentTarget == null) CurrentTarget = GetClosestTarget();

            //TODO: Add preferedTarget and currentTarget
            //Check every update if target is still within shootingrange, if that is the case than make sure there are no other targets within shootingrange with higher priorities 
            if (IsCurrentTargetWithinRange)
            {
                //If there are multiple targets within range, compare their priorities and set the currentTarget to the one with the highest priority
                if (EnemiesInRange.Count > 1)
                {
                    //TODO: Create option for user to change if a battleobject should switch to a higher priority or focus one battleobject down or just keep the current target
                    currentTarget = GetPriorityTarget();
                }
            }
        }

        /// <summary>
        /// Always determine closest target first. If a higher priority target moves in the range of the battleobject, than switch to the higher priority target
        /// </summary>
        /// <returns>Target</returns>
        public GameObject GetClosestTarget()
        {
            GameObject target = boSimController.AliveEnemies.First();
            foreach (GameObject enemy in boSimController.AliveEnemies)
            {
                if (Vector3.Distance(target.transform.position, transform.position) > Vector3.Distance(enemy.transform.position, transform.position))
                {
                    target = enemy;
                }
            }
        
            return target;
        }
        
        /// <summary>
        /// Gets a list of enemies that are in range of the current position. If there's a target with a higher priority, switch to that target or finish a target first. Option for user.
        /// </summary>
        /// <returns></returns>
        public List<GameObject> GetTargetsWithinRange(Transform _transform)
        {
            List<GameObject> targets = new List<GameObject>();
            foreach (GameObject enemy in boSimController.AliveEnemies)
            {
                if (Vector3.Distance(enemy.transform.position, _transform.position) <= boController.BoModel.range)
                {
                    targets.Add(enemy);
                }
            }
        
            return targets;
        }
        
        /// <summary>
        /// Only returns a target when a prioritytarget is within range
        /// </summary>
        /// <returns>Target</returns>
        public GameObject GetPriorityTarget()
        {
            GameObject target = currentTarget;
        
            foreach (GameObject enemy in EnemiesInRange)
            {
                if (currentTarget.GetComponent<BattleObjectController>().settings.priority > enemy.GetComponent<BattleObjectController>().settings.priority)
                {
                    target = enemy;
                }
            }
        
            return target;
        }
    }
}