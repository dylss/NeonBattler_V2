using System;
using Controller.UI;
using UnityEngine;

namespace ScriptableObjects.UI
{
    
    [CreateAssetMenu(menuName = "UI/Button")]
    public abstract class ButtonSO : ScriptableObject, IButton
    {
        public virtual void Click()
        {
            throw new MissingMethodException();
        }
    }
}