using System;
using UnityEngine;
using UnityEngine.Events;

namespace Component.Simulation
{
    public class SimulationEventsComponent : MonoBehaviour
    {
        public static Action startSimulation;
        public static Action startBattling;
        public static Action endSimulation;
        public static Action pauseSimulation;
        public static Action resumeSimulation;
        public static Action speedUpSimulation;
        public static Action slowDownSimulation;

        public void StartSimulation()
        {
            startSimulation?.Invoke();
        }

        public void StartBattling()
        {
            startBattling?.Invoke();
        }
        
        public void EndSimulation()
        {
            endSimulation?.Invoke();
        }
        
        public void PauseSimulation()
        {
            pauseSimulation?.Invoke();
        }

        public void ResumeSimulation()
        {
            resumeSimulation?.Invoke();
        }
        
        public void SpeedUp()
        {
            speedUpSimulation?.Invoke();
        }

        public void SlowDown()
        {
            slowDownSimulation?.Invoke();
        }
    }
}