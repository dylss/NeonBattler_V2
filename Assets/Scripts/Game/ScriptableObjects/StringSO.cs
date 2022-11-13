using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Variable/String")]
    public class StringSO : ScriptableObject
    {
        public string text;
    }
}