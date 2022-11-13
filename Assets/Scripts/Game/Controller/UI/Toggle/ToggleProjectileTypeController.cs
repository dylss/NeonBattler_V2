using System;
using ScriptableObjects;

namespace Controller.UI.Toggle
{
    public class ToggleProjectileTypeController : ToggleController
    {
        public ProjectileType projectileType;

        public event Action<ProjectileType> ProjectileTypeSelected;
        public event Action<ProjectileType> ProjectileTypeDeselected;

        protected override void OnDeselected()
        {
            ProjectileTypeDeselected?.Invoke(projectileType);
        }

        protected override void OnSelected()
        {
            ProjectileTypeSelected?.Invoke(projectileType);
        }
    }
}