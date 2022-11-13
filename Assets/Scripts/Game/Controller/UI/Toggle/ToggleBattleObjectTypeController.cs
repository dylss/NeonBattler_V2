using System;
using ScriptableObjects;

namespace Controller.UI.Toggle
{
    public class ToggleBattleObjectTypeController : ToggleController
    {
        public BattleObjectType battleObjectType;

        public event Action<BattleObjectType> BattleObjectTypeSelected;
        public event Action<BattleObjectType> BattleObjectTypeDeselected;

        protected override void OnDeselected()
        {
            BattleObjectTypeDeselected?.Invoke(battleObjectType);
        }

        protected override void OnSelected()
        {
            BattleObjectTypeSelected?.Invoke(battleObjectType);
        }
    }
}