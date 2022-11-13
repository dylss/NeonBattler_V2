using Model;

namespace DefaultNamespace
{
    [System.Serializable]
    public class InventorySlot
    {
        public InventoryItemAbstract_SO itemObject;
        public int amount;

        public InventorySlot(InventoryItemAbstract_SO itemObject, int amount)
        {
            this.itemObject = itemObject;
            this.amount = amount;
        }

        public void AddAmount(int value)
        {
            amount += amount;
        }
    }
}