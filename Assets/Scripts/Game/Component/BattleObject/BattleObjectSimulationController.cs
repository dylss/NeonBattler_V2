using System;
using System.Collections.Generic;
using Component.BattleObject;
using Game.Component.Simulation;
using Manager;
using Model.Enums;
using ScriptableObjects.RuntimeSets;
using UnityEngine;

namespace Game.Component.BattleObject
{
    public class BattleObjectSimulationController : AbstractSimulationEventListener
    {
        [SerializeField]
        private BattleObjectController battleObjectController;
        [SerializeField] 
        private SimulationManager simulationManager;

        [SerializeField] private bool canBodyMove;
        [SerializeField] private bool canShoot;
        [SerializeField] private bool canMountMove;

        public bool CanBodyMove => canBodyMove;
        public bool CanShoot => canShoot;
        public bool CanMountMove => canMountMove;

        public Team MyTeam
        {
            get
            {
                if (battleObjectController != null) return battleObjectController.settings.team;
                throw new NullReferenceException();
            }
        }
        public List<GameObject> AliveEnemies
        {
            get
            {
                Team myTeam = battleObjectController.settings.team;
                switch (myTeam)
                {
                    case Team.P1:
                        return simulationManager.p2AliveBattleObjects;
                    case Team.P2:
                        return simulationManager.p1AliveBattleObjects;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        public List<GameObject> AliveAllies
        {
            get
            {
                if (battleObjectController == null) throw new TypeInitializationException("BattleObjectController", new Exception());
                if (simulationManager == null) throw new TypeInitializationException("SimulationManager", new Exception());
                Team myTeam = battleObjectController.settings.team;
                switch (myTeam)
                {
                    case Team.P1:
                        return simulationManager.p1AliveBattleObjects;
                    case Team.P2:
                        return simulationManager.p2AliveBattleObjects;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void Awake()
        {
            if(simulationManager == null) simulationManager = GameObject.FindObjectOfType<SimulationManager>();
            
        }
        
        // public override void OnStartSimulation()
        // {
        //     simulationManager.allInitialBattleObjects.Add(this.gameObject);
        //     switch (MyTeam)
        //     {
        //         case Team.P1:
        //             simulationManager.p1InitialBattleObjects.Add(this.gameObject);
        //             simulationManager.p1AliveBattleObjects.Add(this.gameObject);
        //             break;
        //         case Team.P2:
        //             simulationManager.p2InitialBattleObjects.Add(this.gameObject);
        //             simulationManager.p2AliveBattleObjects.Add(this.gameObject);
        //             break;
        //         default:
        //             throw new ArgumentOutOfRangeException();
        //     }
        // }
    }
}