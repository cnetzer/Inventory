using System;
using UnityEngine;

namespace CryoInventory
{
    [Serializable]
    public class Inventory
    {
        public InventorySlot[] Slots;

        public Inventory()
        {
            Slots = Array.Empty<InventorySlot>();
        }
        
        public Inventory(int slots)
        {
            Slots = new InventorySlot[slots];
        }
    }
}