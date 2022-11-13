using System;
using System.Collections.Generic;
using DefaultNamespace;
using Game.ScriptableObjects.BattleObject.ModelSO;
using propertyDrawerCustom;
using ScriptableObjects.BattleObject.ModelSO;
using UnityEngine;

namespace ScriptableObjects.BattleObject
{
    [CreateAssetMenu(menuName = "BattleObject/Model/BattleObject")]
    public class BattleObjectModelSO : ScriptableObject
    {
        public BattleObjectModel battleObjectModel;
        public BodyModelSO body;
        public MountModelSO mount;
        public AbstractProjectileSO projectile;
        public List<EffectModelSO> effects;

        private void OnEnable()
        {
            if(body != null) JsonUtility.FromJsonOverwrite(JsonUtility.ToJson(body), battleObjectModel);
            if(mount != null) JsonUtility.FromJsonOverwrite(JsonUtility.ToJson(mount), battleObjectModel);
            if(projectile != null) JsonUtility.FromJsonOverwrite(JsonUtility.ToJson(projectile), battleObjectModel);
        }
    }
}