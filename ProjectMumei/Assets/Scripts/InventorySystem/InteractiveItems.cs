using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class InteractiveItems : MonoBehaviour
    {
        public Item item;

        void Pickup()
        {
            ItemInventory.instance.Add(item);
        }
    }
}