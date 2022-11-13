using System;
using ScriptableObjects;
using UnityEngine;

namespace Game.Controller.UI.Button
{
    public class ButtonBattleObjectTypeController : ButtonController
    {
        public BattleObjectType battleObjectType;

        public event Action<BattleObjectType> BattleObjectTypeSelected;
        
        public override void Click()
        {
            BattleObjectTypeSelected?.Invoke(battleObjectType);
        }
    }
}