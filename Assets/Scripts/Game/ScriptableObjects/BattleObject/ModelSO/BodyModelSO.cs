using System;
using UnityEngine;

namespace Game.ScriptableObjects.BattleObject.ModelSO
{
    [Serializable]
    [CreateAssetMenu(menuName = "BattleObject/Model/Body")]
    public class BodyModelSO : ScriptableObject
    {
        [TextArea]
        public string description;
        public float maxLinearVel;
        public float maxRotVel;
    }
}