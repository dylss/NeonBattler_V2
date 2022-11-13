using System.Collections.Generic;
using Game.Model.Enums;
using Game.Util.Pathfinding;
using Model.Enums;
using propertyDrawerCustom;
using ScriptableObjects;
using UnityEngine;

namespace DefaultNamespace
{
    [System.Serializable]
    public class BattleObjectSettingsModel
    {
        //Id's
        [_ReadOnly] public long id;
        
        //Global (Database)
        public int price;
        public int priority;
        public Team team;
        public BattleObjectGroundAirType battleObjectGroundAirType;

        //Personal
        public string battleObjectName;
        public List<PathFindingNode> preferredPath;
        public int[] priorityOrder;
        public int gridIndex;
        public bool fixedTarget;
        public MoveToStrategy moveToStrategy = MoveToStrategy.WithinRange;
        
        public enum MoveToStrategy
        {
            WithinRange,
            CloseAsPossible
        }

    }
}