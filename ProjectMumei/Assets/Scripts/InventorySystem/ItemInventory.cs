using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class ItemInventory : MonoBehaviour
    {
        [SerializeField] private Transform _itemDropPosition;
        private Item activeItem;
        [SerializeField] private Image _activeIcon;
        [SerializeField] private Sprite _defaultActiveIcon;

        public static ItemInventory instance;
        public List<Item> items = new List<Item>();
        [SerializeField] private int space = 12;
        public bool bagIsFull;
        public GameObject dropPrefab; //new

        public delegate void OnItemChange();  
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
            dropPrefab = item.prefab;
            Instantiate(dropPrefab, new Vector3(_itemDropPosition.transform.position.x, _itemDropPosition.transform.position.y, _itemDropPosition.transform.position.z), Quaternion.identity);
            items.Remove(item);

            if (item == activeItem)
            {
                activeItem = null;
                _activeIcon.sprite = _defaultActiveIcon;
            }

            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }

        public void ActiveItem(Item item)
        {
            activeItem = item;
            _activeIcon.sprite = activeItem.icon;
        }
    }
}