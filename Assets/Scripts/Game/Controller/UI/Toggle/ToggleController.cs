using System;
using UnityEngine;

namespace Controller.UI.Toggle
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public abstract class ToggleController : MonoBehaviour
    {
        public UnityEngine.UI.Toggle toggle;
        
        public bool Toggled { get; set; }

        public event Action Selected;

        public event Action DeSelected;

        public event Action StartedHoveringOver;
        
        public event Action EndedHoveringOver;

        private void Awake()
        {
            toggle = GetComponent<UnityEngine.UI.Toggle>();
        }

        private void OnEnable()
        {
            toggle.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnDisable()
        {
            toggle.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnValueChanged(bool toggled)
        {
            this.Toggled = toggled;
            if (toggled)
            {
                Selected?.Invoke();
                OnSelected();
            }
            else
            {
                DeSelected?.Invoke();
                OnDeselected();
            }
        }

        protected abstract void OnDeselected();

        protected abstract void OnSelected();
    }
}