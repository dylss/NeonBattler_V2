using Core.Utilities;
using ScriptableObjects.UI.PopupMessageSO;
using UnityEngine;

namespace Game.EmbeddedDatabase
{
    
    public class PopupMessageDatabase : PersistentSingleton<PopupMessageDatabase>
    {
        [SerializeField]
        private PopupMessageSO[] popupMessages;

        public PopupMessageSO PopupMessage(PopupMessageType popupMessageType)
        {
            foreach (var popupMessage in popupMessages)
            {
                if (popupMessage.popupMessageType == popupMessageType)
                {
                    return popupMessage;
                }
            }

            return null;
        }
    }
}