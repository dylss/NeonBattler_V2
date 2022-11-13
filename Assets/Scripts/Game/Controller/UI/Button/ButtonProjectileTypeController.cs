using System;
using ScriptableObjects;
using UnityEngine;

namespace Game.Controller.UI.Button
{
    public class ButtonProjectileTypeController : ButtonController
    {
        public ProjectileType projectileType;

        public event Action<ProjectileType> ProjectileTypeSelected;
        
        public override void Click()
        {
            ProjectileTypeSelected?.Invoke(projectileType);
        }
    }
}