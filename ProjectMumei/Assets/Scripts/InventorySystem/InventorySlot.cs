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
        [SerializeField] private GameObject _itemPrefab;
        [SerializeField] private Transform _itemDropPosition;

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
            _itemPrefab = _item.prefab;
            button.interactable = true;
            //Debug.Log("Get Item Prefab" + _itemPrefab);
        }

        public void ClearSlot()
        {
            _item = null;
            icon.sprite = null;
            icon.enabled = false;
            button.interactable = false;
            //Debug.Log("Drop Item" + _itemPrefab);
        }
        public void OnMouseRightClickRemove()
        {
            if (icon.sprite != null) //Do nothing if no item in the slot
            {
                ItemInventory.instance.RemoveItem(_item);
                Instantiate(_itemPrefab, new Vector3(_itemDropPosition.transform.position.x, _itemDropPosition.transform.position.y, _itemDropPosition.transform.position.z), Quaternion.identity);
            }
        }
    }
}