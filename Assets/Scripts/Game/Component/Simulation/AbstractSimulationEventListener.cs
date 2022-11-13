using System;
using Component.Simulation;
using DefaultNamespace;
using UnityEngine;

namespace Game.Component.Simulation
{
    public abstract class AbstractSimulationEventListener : MonoBehaviour, ISimulationEventListener
    {
        private void OnEnable()
        {
            SimulationEventsComponent.startSimulation += OnStartSimulation;
            SimulationEventsComponent.startBattling += OnStartBattling;
            SimulationEventsComponent.endSimulation += OnEndSimulation;
            SimulationEventsComponent.pauseSimulation += OnPauseSimulation;
            SimulationEventsComponent.resumeSimulation += OnResumeSimulation;
            SimulationEventsComponent.speedUpSimulation += OnSpeedUp;
            SimulationEventsComponent.slowDownSimulation += OnSlowDown;
        }

        private void OnDisable()
        {
            SimulationEventsComponent.startSimulation -= OnStartSimulation;
            SimulationEventsComponent.startBattling -= OnStartBattling;
            SimulationEventsComponent.endSimulation -= OnEndSimulation;
            SimulationEventsComponent.pauseSimulation -= OnPauseSimulation;
            SimulationEventsComponent.resumeSimulation -= OnResumeSimulation;
            SimulationEventsComponent.speedUpSimulation -= OnSpeedUp;
            SimulationEventsComponent.slowDownSimulation -= OnSlowDown;
        }

        public virtual void OnStartSimulation()
        {
        }
        
        public virtual void OnStartBattling()
        {
        }

        public virtual void OnEndSimulation()
        {
        }

        public virtual void OnPauseSimulation()
        {
        }

        public virtual void OnResumeSimulation()
        {
        }

        public virtual void OnSpeedUp()
        {
        }

        public virtual void OnSlowDown()
        {
        }
    }
}