using Controller.UI.Toggle;
using Game.EmbeddedDatabase;
using Manager;
using ScriptableObjects;
using UnityEngine;

namespace Controller.UI
{
    public class BattleObjectSpawnController : MonoBehaviour
    {

        public GameObject battleObjectPrefab;

        public ToggleBattleObjectTypeController battleObjectSelector;
        public ToggleBodyTypeController bodySelector;
        public ToggleProjectileTypeController projectileSelector;

        public BattleObjectType BattleObjectType { get; set; }
        public BodyType BodyType{ get; set; }
        public ProjectileType ProjectileType{ get; set; }
        
        
        
        public void OnEnable()
        {
            battleObjectSelector.BattleObjectTypeSelected += BattleObjectSelectedHandler;
            bodySelector.BodyTypeSelected += BodySelectedHandler;
            projectileSelector.ProjectileTypeSelected += ProjectileSelectedHandler;
            
            battleObjectSelector.BattleObjectTypeSelected += BattleObjectSelectedHandler;
            bodySelector.BodyTypeSelected += BodySelectedHandler;
            projectileSelector.ProjectileTypeSelected += ProjectileSelectedHandler;

        }

        public void OnDisable()
        {
            battleObjectSelector.BattleObjectTypeSelected -= BattleObjectSelectedHandler;
            bodySelector.BodyTypeSelected -= BodySelectedHandler;
            projectileSelector.ProjectileTypeSelected -= ProjectileSelectedHandler;
            
            battleObjectSelector.BattleObjectTypeSelected -= BattleObjectSelectedHandler;
            bodySelector.BodyTypeSelected -= BodySelectedHandler;
            projectileSelector.ProjectileTypeSelected -= ProjectileSelectedHandler;
        }

        public void BattleObjectSelectedHandler(BattleObjectType battleObjectType)
        {
            if (battleObjectType == null)
            {
                throw new MissingReferenceException("BattleObject missing");
            }

            this.BattleObjectType = battleObjectType;
            
            SelectionValidator();
        }

        public void BodySelectedHandler(BodyType bodyType)
        {
            if (bodyType == null)
            {
                throw new MissingReferenceException("Body missing");
            }

            this.BodyType = bodyType;
            
            SelectionValidator();
        }

        public void ProjectileSelectedHandler(ProjectileType projectileType)
        {
            if (projectileType == null)
            {
                throw new MissingReferenceException("Projectile missing");
            }

            this.ProjectileType = projectileType;
            
            SelectionValidator();
        }

        public void SelectionValidator()
        {
            if (!battleObjectSelector.Toggled)
            {
                return;
            }

            if (!bodySelector.Toggled)
            {
                
            }
        }
    }
}