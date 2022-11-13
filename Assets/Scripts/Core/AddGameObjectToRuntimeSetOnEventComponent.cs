using ScriptableObjects.RuntimeSets;
using UnityEngine;

namespace Core
{
    public class AddGameObjectToRuntimeSetOnEventComponent : MonoBehaviour
    {
        public GameObjectRuntimeSet runtimeSet;
        public GameObject go;
        
        public void AddToRuntimeSet()
        {
            runtimeSet.Add(go);
        }
    }
}