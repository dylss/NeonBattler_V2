using System;
using System.Collections.Generic;
using DefaultNamespace;
using ScriptableObjects;
using ScriptableObjects.BattleObject;
using UnityEngine;

[ExecuteInEditMode]
public class BattleObjectController : MonoBehaviour
{
    public BattleObjectModelSO boSO;
    public BattleObjectSettingsModel settings;
    public BattleObjectModel BoModel
    {
        get
        {
            return boSO.battleObjectModel;
        }
    }

    // public BattleObjectSettingsModel battleObjectSettingsModel;
    // public BattleObjectModel battleObjectModel;
    //
    // public BattleObjectType battleObjectType;
    // public BodyType bodyType;
    // public MountType mountType;
    // public BarrelType barrelType;
    // public ProjectileType projectileType;
    // public ArmorType armorType;
    // public List<DamageType> damageTypes;
    //
    // public void OnInitialization()
    // {
    //     
    // }
    //
    // public void Upgrade()
    // {
    //     
    // }
    //
    // private void OnValidate()
    // {
    //     SetBattleObjectModelData();
    // }
    //
    // public void SetBattleObjectModelData()
    // {
    //     // JsonUtility.FromJsonOverwrite(JsonUtility.ToJson(bodyType.bodyModel), battleObjectModel);
    //     // JsonUtility.FromJsonOverwrite(JsonUtility.ToJson(mountType.mountModel), battleObjectModel);
    //     // JsonUtility.FromJsonOverwrite(JsonUtility.ToJson(barrelType.barrelModel), battleObjectModel);
    //     // JsonUtility.FromJsonOverwrite(JsonUtility.ToJson(projectileType.projectileModel), battleObjectModel);
    // }
}
