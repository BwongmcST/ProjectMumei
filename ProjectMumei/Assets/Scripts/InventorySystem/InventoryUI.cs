using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class InventoryUI : MonoBehaviour
    {
        public Transform itemsPartent;

        InventorySlot[] slots;

        private ItemInventory _inventory;
        // Start is called before the first frame update
        void Start()
        {
            _inventory = ItemInventory.instance;
            _inventory.onItemChangedCallback += UpdateUI; // if onItemChangedCallback invoke, run UpdageUI();

            slots = itemsPartent.GetComponentsInChildren<InventorySlot>(); //Find all inventory slot and store in slots arrays
        }

        void UpdateUI()
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (i < _inventory.items.Count)
                {
                    slots[i].AddItem(_inventory.items[i]);
                }
                else
                {
                    slots[i].ClearSlot();
                }
            }

        }
    }
}