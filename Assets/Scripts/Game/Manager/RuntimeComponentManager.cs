using System.Collections.Generic;
using Core.Utilities;
using ScriptableObjects.RuntimeSets;
using UnityEngine;

namespace Manager
{
    public class RuntimeComponentManager : Singleton<RuntimeComponentManager>
    {
        public GameObjectRuntimeSet aliveBattleObjects;

        private HashSet<MeshCollider> cachedMeshColliders;

        public HashSet<MeshCollider> getMeshColliders()
        {
            MeshCollider meshCollider;
            return cachedMeshColliders;
        }
        
        private void OnEnable()
        {
            aliveBattleObjects.addEvent += cacheEnemyMeshes;
            aliveBattleObjects.removeEvent += cacheEnemyMeshes;
        }

        private void cacheEnemyMeshes(GameObject go)
        {
            foreach (GameObject enemy in aliveBattleObjects.items)
            {
                // cachedMeshColliders
            }
        }
    }
}