using System;
using System.Collections.Generic;
using System.Linq;
using Component;
using Component.BattleObject;
using DefaultNamespace;
using Game.Util.Pathfinding;
using propertyDrawerCustom;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Game.Component.BattleObject
{
    public class HexagonalMovementComponent : MonoBehaviour
    {
        [SerializeField] private HexagonGridCreatorComponent hexGridCreatorComponent;
        [SerializeField] private BattleObjectController boController;
        [SerializeField] private TargetAcquisitionComponent targetAquisitionComponent;
        [SerializeField] private BattleObjectSimulationController boSimController;
        [SerializeField] private PathfindingComponent pathfindingComponent;
        [_ReadOnly] public GameObject targetHex;
        
        private float rangeRef => boController.BoModel.range;
        private List<GameObject> gridRef => hexGridCreatorComponent.grid;
        private BattleObjectSettingsModel.MoveToStrategy moveToStrategyRef => boController.settings.moveToStrategy;

        private PathFindingNode targetNode;
        private HexagonalMovementState hexMovementState = HexagonalMovementState.Idle;
        
        public enum HexagonalMovementState
        {
            Idle,
            Moving
        }

        private void Update()
        {
            //If there is no target, than return
            if(!targetAquisitionComponent.CurrentTarget) return;
            
            //If target is within range, than return (No movement needed)
            if(targetAquisitionComponent.IsCurrentTargetWithinRange) return;

            targetHex = GetHexagonToMoveTo();

        }

        private GameObject GetHexagonToMoveTo()
        {
            switch (moveToStrategyRef)
            {
                case BattleObjectSettingsModel.MoveToStrategy.WithinRange:
                    return GetHexagonWithinRange(targetAquisitionComponent.CurrentTarget);
                case BattleObjectSettingsModel.MoveToStrategy.CloseAsPossible: 
                    return GetHexagonClosestToTarget(targetAquisitionComponent.CurrentTarget);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private GameObject GetHexagonWithinRange(GameObject currentTarget)
        {
            GameObject closestHex = gridRef.First();
            float closestHexDist = Vector3.Distance(transform.position, closestHex.transform.position);
            foreach (GameObject hexagon in gridRef)
            {
                float hexTargetDistance = 
                    Vector3.Distance(hexagon.transform.position, currentTarget.GetComponent<HitPointComponent>().hitPoint.position);
                if (hexTargetDistance < rangeRef)
                {
                    float hexagonDist = Vector3.Distance(transform.position, hexagon.transform.position);
                    if (closestHexDist > hexagonDist)
                    {
                        closestHex = hexagon;
                    }
                }
            }

            return closestHex;
        }

        private GameObject GetHexagonClosestToTarget(GameObject currentTarget)
        {
            return null;
        }

        private void FollowLine()
        {
            
        }
    }
}