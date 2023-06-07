using System;

namespace CryoInventory
{
    [Serializable]
    public class Item
    {
        public ItemData Data;

        public Item()
        {
            Data = null;
        }
        
        public Item(ItemData data)
        {
            Data = data;
        }
    }
}