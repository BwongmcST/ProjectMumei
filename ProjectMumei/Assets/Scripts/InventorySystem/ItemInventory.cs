using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class ItemInventory : MonoBehaviour
    { 

        [SerializeField] private int space = 12;
        public delegate void OnItemChange();
        public OnItemChange onItemChangedCallback;

        [Header("Drag to Pre-Assign:")]
        [SerializeField] private Transform _itemDropPosition;
        [SerializeField] private Image _activeIcon;
        [SerializeField] private Sprite _defaultActiveIcon;
        [SerializeField] private Transform _equipmentPos;

        [Header("Auto Assign")]
        [SerializeField] private GameObject _equipPrefab;
        public Item activeItem;
        public string selectedItemInfo;
        public string selectedItemName;
        public bool bagIsFull;
        public bool bagIsOpen;
        public GameObject dropPrefab; //new

        public List<Item> items = new List<Item>();
        public static ItemInventory instance;

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
                Destroy(_equipPrefab);
            }
        }

        public void ActiveItem(Item item)
        {
            activeItem = item;
            _activeIcon.sprite = activeItem.icon;

            if (activeItem.isWeapon == true)
            {
                _equipPrefab = Instantiate(activeItem.prefab, _equipmentPos);
                Destroy(_equipPrefab.GetComponent<Rigidbody>());
                _equipPrefab.GetComponentInChildren<Gun>().enabled = true;
            }
            else
            {
                Destroy(_equipPrefab);
            }
        }

        public void ShowItemInfo(Item item)
        {
            selectedItemName = item.name;
            selectedItemInfo = item.description;
        }

    }
}