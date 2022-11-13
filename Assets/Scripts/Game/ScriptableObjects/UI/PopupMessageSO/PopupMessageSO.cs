using Game.EmbeddedDatabase;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptableObjects.UI.PopupMessageSO
{
    public class PopupMessageSO : ScriptableObject
    {
        public PopupMessageType popupMessageType;
        public Text message;
    }
}