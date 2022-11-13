using System;
using System.Collections.Generic;
using ScriptableObjects.RuntimeSets;
using UnityEngine;
using Util;

namespace Component
{
    public class RuntimeItemComponent : MonoBehaviour, ISimulatorObject
    {
        public List<GameObjectRuntimeSet> simulationRuntimeSets;

        public void OnStartSimulation()
        {
            foreach (var runtimeSet in simulationRuntimeSets)
            {
                runtimeSet.Add(gameObject);
            }
        }

        public void OnEndSimulation()
        {
            foreach (var runtimeSet in simulationRuntimeSets)
            {
                runtimeSet.Remove(gameObject);
            }
        }

        public void OnPauseSimulation()
        {
            throw new System.NotImplementedException();
        }

        private void OnDisable()
        {
            foreach (var runtimeSet in simulationRuntimeSets)
            {
                runtimeSet.Remove(gameObject);
            }
        }

        private void OnDestroy()
        {
            
        }
    }
}