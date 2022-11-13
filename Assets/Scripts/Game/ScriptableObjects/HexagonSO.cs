using UnityEngine;

namespace ScriptableObjects
{
    public class HexagonSO : ScriptableObject
    {
        public string name { get; set; }
        public int gridIndex { get; set; }
        public HexCoordinates hexCoordinates { get; set; }
    }
}