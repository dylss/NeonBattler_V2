using System;
using System.Collections.Generic;
using Component;
using Model.Enums;
using UnityEngine;

namespace Manager
{
    public class SpawnManager : MonoBehaviour
    {
        public HexagonGridCreatorComponent hexagonGridCreatorComponent;
        public SimulationManager simulationManager;

        public bool SpawnBattleObjects(List<GameObject> p1BattleObjects, List<GameObject> p2BattleObjects)
        {
            foreach (GameObject battleObject in p1BattleObjects)
            {
                SpawnComponent spawnComponent = battleObject.GetComponent<SpawnComponent>();
                BattleObjectController battleObjectController = battleObject.GetComponent<BattleObjectController>();
                int gridIndex = battleObjectController.settings.gridIndex;
                spawnComponent.SpawnPos = DetermineSpawnPosFromGridIndex(gridIndex);
                spawnComponent.SpawnRot = DetermineSpawnRotFromTeam(Team.P1);
                spawnComponent.StartSpawn(SpawnComponent.SpawnType.INSTANT);
            }
        
            foreach (GameObject battleObject in p2BattleObjects)
            {
                var spawnComponent = battleObject.GetComponent<SpawnComponent>();
                var battleObjectController = battleObject.GetComponent<BattleObjectController>();
                int gridIndex = battleObjectController.settings.gridIndex;
                spawnComponent.SpawnPos = DetermineSpawnPosFromGridIndex(gridIndex);
                spawnComponent.SpawnRot = DetermineSpawnRotFromTeam(Team.P2);
                spawnComponent.StartSpawn(SpawnComponent.SpawnType.INSTANT);
            }

            return true;
        }
    
        private Quaternion DetermineSpawnRotFromTeam(Team team)
        {
            switch (team)
            {
                case Team.P1:
                    return Quaternion.Euler(0, 90, 0);
                case Team.P2:
                    return Quaternion.Euler(0, -90, 0);
                default:
                    throw new ArgumentOutOfRangeException(nameof(team), team, null);
            }
        }

        private Vector3 DetermineSpawnPosFromGridIndex(int gridIndex)
        {
            return hexagonGridCreatorComponent.GetSpawnPosFromGridIndex(gridIndex);
        }
        
#if UNITY_EDITOR
        public void ManuallySpawnBattleObjects()
        {
            GameObject p1 = simulationManager.p1;
            GameObject p2 = simulationManager.p2;

            List<GameObject> p1InitialBattleObjects = new List<GameObject>();
            List<GameObject> p2InitialBattleObjects = new List<GameObject>();
            List<GameObject> p1AliveBattleObjects = new List<GameObject>();
            List<GameObject> p2AliveBattleObjects = new List<GameObject>();
            
            for (int i = 0; i < p1.transform.childCount; i++)
            {
                var child = p1.transform.GetChild(i);
                GameObject childBO = p1.transform.GetComponentInChildren<BattleObjectController>().gameObject;
                p1InitialBattleObjects.Add(childBO);
                p1AliveBattleObjects.Add(childBO);
            }
            
            for (int i = 0; i < p2.transform.childCount; i++)
            {
                var child = p2.transform.GetChild(i);
                GameObject childBO = p2.transform.GetComponentInChildren<BattleObjectController>().gameObject;
                p2InitialBattleObjects.Add(childBO);
                p2AliveBattleObjects.Add(childBO);
            }

            SpawnBattleObjects(p1InitialBattleObjects, p2InitialBattleObjects);
        }  
#endif
    }
}
