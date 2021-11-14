using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace InventorySystem
{
    public class InventorySlot : MonoBehaviour
    {
        private Item _item;
        private Button button;

        [Header("Drag to Pre-Assign:")]
        public Image icon;
        [SerializeField] private GameObject _itemInfoPanel;
        [SerializeField] private Text _ItemNameText;
        [SerializeField] private Text _itemInfoText;

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
                CloseItemPanel();
            }
        }

        public void OnMouseLeftClickSelect()
        {
            if (icon.sprite != null && ItemInventory.instance.activeItem != _item)
            {
                ItemInventory.instance.ActiveItem(_item);
                CloseItemPanel();
            }
        }

        public void OnPointerOver()       // Show item details when mouse point over the inventory button
        {
            if (icon.sprite != null)
            {
                ItemInventory.instance.ShowItemInfo(_item);
                _itemInfoPanel.SetActive(true);
                _ItemNameText.text = ItemInventory.instance.selectedItemName;
                _itemInfoText.text = ItemInventory.instance.selectedItemInfo;
            }
        }
        public void OnPointerExit()       // Show item details when mouse point over the inventory button
        {
            if(_itemInfoPanel.activeSelf == true)
            {
                CloseItemPanel();
            }
        }

        public void CloseItemPanel()
        {
            _itemInfoPanel.SetActive(false);
            _ItemNameText.text = null;
            _itemInfoText.text = null;
        }
    }
}