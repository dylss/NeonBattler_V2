using System;
using UnityEngine;

namespace Component.BattleObject
{
    public class DestroyComponent : MonoBehaviour
    {
        public static event Action<GameObject> destroy;

        public void OnDestroyCustom()
        {
            
        }
    }
}