using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class InventoryUI : MonoBehaviour
    {
        public Transform itemsPartent;

        InventorySlot[] slots;

        private ItemInventory _itemInventory;
        // Start is called before the first frame update
        void Start()
        {
            _itemInventory = ItemInventory.instance;
            _itemInventory.onItemChangedCallback += UpdateUI; // if onItemChangedCallback invoke, run UpdageUI();

            slots = itemsPartent.GetComponentsInChildren<InventorySlot>(); //Find all inventory slot and store in slots arrays
        }

        void UpdateUI()
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (i < _itemInventory.items.Count)
                {
                    slots[i].AddItem(_itemInventory.items[i]);
                }
                else
                {
                    slots[i].ClearSlot();
                }
            }

            
        }
    }
}