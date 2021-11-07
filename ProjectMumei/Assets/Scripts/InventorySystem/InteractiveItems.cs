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
            Debug.Log("Item" + item.name + "pickedup");
            ItemInventory.instance.Add(item);
        }
    }
}