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
        [SerializeField] private GameObject AmmoUI;
        private Item _lastItem;

        [Header("Auto Assign")]
        [SerializeField] private GameObject _equipPrefab;
        public Item activeItem;
        public Item activeAmmo;
        public bool itemIsActive = false;
        public string selectedItemInfo;
        public string selectedItemName;
        public bool bagIsFull;
        public bool bagIsOpen;
        public GameObject dropPrefab; //new
        [SerializeField] private int _currentTotalActiveAmmo;

        public List<Item> items = new List<Item>();
        public List<Item> ammo = new List<Item>();
        private static ItemInventory _instance;
        public static ItemInventory instance
        {
            get { return _instance; }
        }

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
        }
        public void Add(Item item)
        {

            if (items.Count >= space)
            {
                Debug.Log("Bag is full!");
                bagIsFull = true;
                return;
            }

            if (item.isAmmo == true)
            {
                if (AmmoManager.instance != null)
                {
                    AmmoManager.instance.AddAmmo(item);
                }

                foreach (Item i in items)
                {
                    if (i.isAmmo == true && i.AmmoType == item.AmmoType)
                    {
                        return;
                    }
                }

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
            GameObject newObject = Instantiate(dropPrefab, new Vector3(_itemDropPosition.transform.position.x, _itemDropPosition.transform.position.y, _itemDropPosition.transform.position.z), Quaternion.identity);
            newObject.transform.localScale = new Vector3(item.scale, item.scale, item.scale);
            items.Remove(item);

            if (item == activeItem)
            {
                activeItem = null;
                _activeIcon.sprite = _defaultActiveIcon;
                itemIsActive = false;

            }

            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
                Destroy(_equipPrefab);
            }
        }

        public void ActiveItem(Item item)
        {
                itemIsActive = true;
                activeItem = item;
                _activeIcon.sprite = activeItem.icon;
                _currentTotalActiveAmmo = 0;


            if (activeItem.isWeapon == true && _equipPrefab == null)
            {
                _equipPrefab = Instantiate(activeItem.prefab, _equipmentPos);
                Destroy(_equipPrefab.GetComponent<Rigidbody>());
                CheckAmmo();
                AmmoManager.instance.UseAmmo();
                //_equipPrefab.GetComponentInChildren<Gun>().enabled = true;
            }
            else if (activeItem.isWeapon == true)
            {
                Destroy(_equipPrefab);
                _equipPrefab = Instantiate(activeItem.prefab, _equipmentPos);
                Destroy(_equipPrefab.GetComponent<Rigidbody>());
                CheckAmmo();
                AmmoManager.instance.UseAmmo();
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

        private void CheckAmmo()
        {

            foreach (Item i in items)
            {
                if (i.isAmmo == true && i.AmmoType == activeItem.weaponIndex)
                {
                    _currentTotalActiveAmmo = _currentTotalActiveAmmo + i.CurrentAmmoAmount;
                    //Debug.Log(_currentTotalActiveAmmo);
                }
            }
        }
    }
}