using System.Collections.Generic;
using DefaultNamespace;
using Game.ScriptableObjects.Util.Inventory;
using UnityEngine;

namespace ScriptableObjects.Util.EmbeddedDatabase
{
    
    [CreateAssetMenu(fileName = "New Item Dabase", menuName = "Inventory/Items/Database")]
    public class DatabaseSO : ScriptableObject
    {
        // public ItemSO[] Items;
        // public Dictionary<ItemSO, int> GetId = new Dictionary<ItemSO, int>();
        // // public Dictionary<int, ItemSO> GetItem = new Dictionary<int, ItemSO>();
        //
        // public void OnAfterDeserialize()
        // {
        //     GetId = new Dictionary<ItemSO, int>();
        //     for (int i = 0; i < Items.Length; i++)
        //     {
        //         GetId.Add(Items[i], i);
        //     }
        // }
        //
        // public void OnBeforeSerialize()
        // {
        //     
        // }

        public ItemSO[] Items;
        public Dictionary<int, ItemSO> GetItem = new Dictionary<int, ItemSO>();

        public void OnAfterDeserialize()
        {
            for (int i = 0; i < Items.Length; i++)
            {
                Items[i].Id = i;
                GetItem.Add(i, Items[i]);
            }
        }

        public void OnBeforeSerialize()
        {
            GetItem = new Dictionary<int, ItemSO>();
        }
    }
}