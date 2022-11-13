using UnityEngine;

namespace Model
{
    public abstract class InventoryItemAbstract_SO : ScriptableObject
    {
        public GameObject prefab;
        // public ItemType type;
        [TextArea(15,20)]
        public string description;
    }
}