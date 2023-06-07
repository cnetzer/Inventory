using UnityEngine;

namespace CryoInventory
{
    [CreateAssetMenu]
    public class ItemData : ScriptableObject
    {
        public int Id;
        public string ItemName;
        public ItemType Type;

        public bool Stackable;
    }
}