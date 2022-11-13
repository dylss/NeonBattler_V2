using System;
using System.Collections.Generic;
using System.Threading;
using Component.Simulation;
using DefaultNamespace;
using Game.Component.Simulation;
using ScriptableObjects.RuntimeSets;
using UnityEngine;

namespace Manager
{
    public class SimulationManager : AbstractSimulationEventListener
    {
        //List of all battleobjects with startpositions
        // public GameObjectRuntimeSet p1InitialBattleObjects;
        // public GameObjectRuntimeSet p2InitialBattleObjects;
        // public GameObjectRuntimeSet allInitialBattleObjects;
        // public GameObjectRuntimeSet p1AliveBattleObjects;
        // public GameObjectRuntimeSet p2AliveBattleObjects;

        public List<GameObject> p1InitialBattleObjects = new List<GameObject>();
        public List<GameObject> p2InitialBattleObjects = new List<GameObject>();
        public List<GameObject> allInitialBattleObjects = new List<GameObject>();
        public List<GameObject> p1AliveBattleObjects = new List<GameObject>();
        public List<GameObject> p2AliveBattleObjects = new List<GameObject>();
        
        [SerializeField]
        private SpawnManager spawnManager;

        public GameObject p1;
        public GameObject p2;

        [SerializeField] private SimulationEventsComponent simulationEventsComponent;
        
        private void Awake()
        {
            if (simulationEventsComponent == null)
                simulationEventsComponent = GetComponent<SimulationEventsComponent>();
        }

        public List<GameObject> GetAllBattleObjects()
        {
            List<GameObject> list = new List<GameObject>();
            list.AddRange(p1InitialBattleObjects);
            list.AddRange(p2InitialBattleObjects);
            return list;
        }

        public override void OnStartSimulation()
        {
            //Start timer: 5 to 0
            //Initialize prefabs??
            //TODO: Idea, As battleobject add itself to these lists when Location is battleground. (Not really safe, because can't really be checked anywhere)
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

            //Spawn battleObjects -> SpawnManager.SpawnBattleObjects() -> callback everything is in place
            bool allInPlace = spawnManager.SpawnBattleObjects(p1InitialBattleObjects, p2InitialBattleObjects);
            if (allInPlace)
            {
                simulationEventsComponent.StartBattling();
            }
        }

        public override void OnStartBattling()
        {
            //Release all battleobject locks; movement, mountmovement, shooting, etc.
            
            
        }
    }
}