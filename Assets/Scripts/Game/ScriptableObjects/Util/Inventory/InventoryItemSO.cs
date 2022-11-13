using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "Inventory/item")]
    public class InventoryItemSO : ScriptableObject
    {
        public GameObject[] gameObjects;

    }
}