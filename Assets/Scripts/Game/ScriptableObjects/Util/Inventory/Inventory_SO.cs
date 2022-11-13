using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "new inventory", menuName = "Util/Inventory")]
    public class Inventory_SO : ScriptableObject
    {
        public List<InventorySlot> container = new List<InventorySlot>();
    }
}