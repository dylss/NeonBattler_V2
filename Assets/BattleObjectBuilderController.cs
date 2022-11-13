using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using Editor;
using Model.Enums;
using ScriptableObjects;
using UnityEngine;

[ExecuteInEditMode]
public class BattleObjectBuilderController : MonoBehaviour
{
    public List<BattleObjectType> battleObjectTypes;
    public List<BodyType> bodyTypes;
    public List<BarrelType> barrelTypes;
    public List<ProjectileType> projectileTypes;

    public BattleObjectType battleObjectType;
    public BodyType bodyType;
    public BarrelType barrelType;
    public ProjectileType projectileType;
    
    public static List<string> tmpList1;
    public static List<string> tmpList2;
    public static List<string> tmpList3;
    public static List<string> tmpList4;

    [HideInInspector] public List<string> BattleObjectTypeStrings;
    [HideInInspector] public List<string> BodyTypesStrings;
    [HideInInspector] public List<string> BarrelTypesStrings;
    [HideInInspector] public List<string> ProjectileTypesStrings;
    
    [ListToPopup(typeof(BattleObjectBuilderController), "tmpList1")]
    public string BattleObject;
    
    [ListToPopup(typeof(BattleObjectBuilderController), "tmpList2")]
    public string Body;
    
    [ListToPopup(typeof(BattleObjectBuilderController), "tmpList3")]
    public string Barrel;
    
    [ListToPopup(typeof(BattleObjectBuilderController), "tmpList4")]
    public string Projectile;
    
    public void UpdateSelection()
    {
        ClearAll();
        
        //Add strings to battleObject strings list to show
        battleObjectTypes.ForEach(type => BattleObjectTypeStrings.Add(type.name));
        //Copy list to static tmp list, no idea why
        tmpList1 = BattleObjectTypeStrings;
        
        //Find battleObjectType of type Scriptable object via corresponding name from string list
        battleObjectType = battleObjectTypes.First(bo => bo.name == BattleObject);
        
        //If name could not be found then return
        if(battleObjectType == null) return;
        
        //Add strings to corresponding lists to show up in the dropdownlists in the inspector
        battleObjectType.bodyTypes.ForEach(type => BodyTypesStrings.Add(type.name));
        battleObjectType.barrelTypes.ForEach(type => BarrelTypesStrings.Add(type.name));
        battleObjectType.projectileTypes.ForEach(type => ProjectileTypesStrings.Add(type.name));
        
        //Copy lists to static tmp lists
        tmpList2 = BodyTypesStrings;
        tmpList3 = BarrelTypesStrings;
        tmpList4 = ProjectileTypesStrings;
        
        //Find types from corresponding names
        bodyType = bodyTypes.First(bo => bo.name == Body);
        barrelType = barrelTypes.First(bo => bo.name == Barrel);
        projectileType = projectileTypes.First(bo => bo.name == Projectile);
    }

    public void ClearAll()
    {
        battleObjectType = null;
        bodyType = null;
        barrelType = null;
        projectileType = null;
        
        BattleObjectTypeStrings = new List<string>();
        BodyTypesStrings = new List<string>();
        BarrelTypesStrings = new List<string>();
        ProjectileTypesStrings = new List<string>();

        if (tmpList1 != null && tmpList1.Count != 0)
        {
            tmpList1.Clear();
            tmpList2.Clear();
            tmpList3.Clear();
            tmpList4.Clear();   
        }
    }
    
    public void Build()
    {
    }
}
