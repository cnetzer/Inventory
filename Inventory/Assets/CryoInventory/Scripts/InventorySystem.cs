using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using S = UnityEngine.SerializeField;

namespace CryoInventory
{
    public class InventorySystem : MonoBehaviour
    {
        [Header("Inventory")]
        public Inventory inventory = null;

        [Header("Settings")]
        public int Slots = 4;

        public void CreateInventory()
        {
            inventory = new Inventory(Slots);
        }

        public void DeleteInventory()
        {
            inventory = new Inventory();
        }

        public bool AddItem(Item item, int amount = 1)
        {
            if (item == null) return false;
            
            InventorySlot slot = FindItem(item);
            if (slot != null)
            {
                if (slot.Item.Data.Stackable)
                {
                    slot.AddAmount(amount);
                    return true;
                }
            }
            
            if (EmptySlotCount() < 0) return false;
            SetEmptySlot(item);

            return true;
        }

        private void SetEmptySlot(Item item)
        {
            if (item == null) return;
            
            foreach (var slot in inventory.Slots)
            {
                if (!slot.Empty()) continue;
                
                slot.SetSlot(item);
                break;
            }
            
        }

        private InventorySlot FindItem(Item item)
        {
            if (item == null) return null;

            foreach (var slot in inventory.Slots)
            {
                if (slot.Empty() || slot.Item.Data.Id != item.Data.Id) continue;

                return slot;
                break;
            }

            return null;
        }

        private int EmptySlotCount()
        {
            return inventory.Slots.Count(slot => slot.Empty());
        }
    }
}