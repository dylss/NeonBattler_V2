using System;
using ScriptableObjects;
using UnityEngine;

namespace Game.Controller.UI.Button
{
    public class ButtonBodyTypeController : ButtonController
    {
        public BodyType bodyType;

        public event Action<BodyType> BodyTypeSelected;
        
        public override void Click()
        {
            BodyTypeSelected?.Invoke(bodyType);
        }
    }
}