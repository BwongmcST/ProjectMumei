using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class InventorySlot : MonoBehaviour
    {
        private Item _item;
        public Image icon;
        private Button button;

        private void Start()
        {

            button = gameObject.GetComponentInChildren<Button>();
            button.interactable = false;

        }

        public void AddItem(Item newItem)
        {
            _item = newItem;
            icon.sprite = _item.icon;
            icon.enabled = true;
            button.interactable = true;
        }

        public void ClearSlot()
        {
            _item = null;
            icon.sprite = null;
            icon.enabled = false;
            button.interactable = false;
        }
        public void OnMouseRightClickRemove()
        {
            if (icon.sprite != null) //Do nothing if no item in the slot
            {
                ItemInventory.instance.RemoveItem(_item);
            }
        }
        
        public void OnMouseLeftClickSelect()
        {
            if(icon.sprite != null)
            {
                ItemInventory.instance.ActiveItem(_item);
            }
        }
    }
}