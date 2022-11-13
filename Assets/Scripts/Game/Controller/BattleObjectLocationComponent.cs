using System;
using Model.Enums;
using UnityEngine;

namespace Controller
{
    public class BattleObjectLocationComponent : MonoBehaviour
    {
        public BattleObjectLocation CurrentLocation { get; private set; }
        public BattleObjectLocation PreviousLocation { get; private set; }

        public static event Action<GameObject> LocationChanged;
        
        public void InitialLocation(BattleObjectLocation location)
        {
            CurrentLocation = location;
        }
        
        public void ChangeLocation(BattleObjectLocation location)
        {
            PreviousLocation = CurrentLocation;
            CurrentLocation = location;
            LocationChanged?.Invoke(gameObject);
        }
    }
}