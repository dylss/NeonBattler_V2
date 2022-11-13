using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Enums/ProjectileCurveType")]
    public class ProjectileCurveType : ScriptableObject
    {
        [TextArea]
        public string description;
    }
}