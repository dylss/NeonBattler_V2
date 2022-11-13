using DefaultNamespace;
using UnityEngine;

namespace Controller
{
    public class ProjectileModelController : MonoBehaviour
    {
        public ProjectileModel projectileModel;
        public float Damage
        {
            get
            {
                return projectileModel.damage;
            }
        }
        
    }
}