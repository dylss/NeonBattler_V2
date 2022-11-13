using System;
using Controller.UI;
using UnityEngine;

namespace Game.Controller.UI.Button
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public abstract class ButtonController : MonoBehaviour, IButton
    {
        public UnityEngine.UI.Button button;

        public event Action Selected;

        public event Action DeSelected;

        public event Action StartedHoveringOver;
        
        public event Action EndedHoveringOver;

            private void Awake()
        {
            button = GetComponent<UnityEngine.UI.Button>();
        }

        private void OnEnable()
        {
            button.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            Click();
        }

        public abstract void Click();
    }
}