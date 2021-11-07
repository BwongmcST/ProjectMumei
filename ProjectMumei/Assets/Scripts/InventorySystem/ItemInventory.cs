using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class ItemInventory : MonoBehaviour
    {

        public static ItemInventory instance;
        public List<Item> items = new List<Item>();
        [SerializeField] private int space = 12;
        public bool bagIsFull;

        public delegate void OnItemChange();   //---
        public OnItemChange onItemChangedCallback;

        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogWarning("There is more than one instance!");
                return;
            }
            instance = this;
        }
        public void Add(Item item)
        {
            if (items.Count >= space)
            {
                Debug.Log("Bag is full!");
                bagIsFull = true;
                return;
            }
            bagIsFull = false;
            items.Add(item);

            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }

        }

        public void RemoveItem(Item item)
        {
            items.Remove(item);

            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }
    }
}