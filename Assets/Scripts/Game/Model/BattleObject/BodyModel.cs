using ScriptableObjects;
using UnityEngine;

namespace DefaultNamespace
{
    [System.Serializable]
    public class BodyModel
    {
        public BodyType bodyType;
        public float maxLinearVel;
        public float maxRotVel;
        
        //Editor only
        public float vecPosAccuracy = 1f;
    }
}