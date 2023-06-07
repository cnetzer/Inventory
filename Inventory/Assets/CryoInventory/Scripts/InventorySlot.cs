using System;

namespace CryoInventory
{
    [Serializable]
    public class InventorySlot
    {
        public Item Item;
        public int Stack;

        public InventorySlot()
        {
            Item = new Item();
            Stack = 0;
        }

        public bool Empty() => Item.Data == null;

        public void SetSlot(Item item, int stack = 1)
        {
            Item = item;
            Stack = stack;
        }

        public void AddAmount(int amount)
        {
            Stack += amount;
        }
    }
}