using System;
using ScriptableObjects;

namespace Controller.UI.Toggle
{
    public class ToggleBodyTypeController : ToggleController
    {
        public BodyType bodyType;

        public event Action<BodyType> BodyTypeSelected;
        public event Action<BodyType> BodyTypeDeselected;

        protected override void OnDeselected()
        {
            BodyTypeDeselected?.Invoke(bodyType);
        }

        protected override void OnSelected()
        {
            BodyTypeSelected?.Invoke(bodyType);
        }
    }
}