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
        [SerializeField] private Text ammoText;
 
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

        public List<Item> items = new List<Item>();
        public List<Item> ammo = new List<Item>();

        private GameObject _pickedUpObject;  //ammo drop system test
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

        private void Update()
        {
            CheckActiveItemAmmo();
        }


        public void Add(Item item, GameObject gameobject)
        {
            _pickedUpObject = gameobject;
            InteractiveItems interactiveItems = gameobject.GetComponent<InteractiveItems>();

            if (items.Count >= space)
            {
                Debug.Log("Bag is full!");
                bagIsFull = true;
                return;
            }

            if (item.isAmmo == true)                                                    //check ammo if ammo is used (isLeft = true if ammo dropped)
            {
                if(interactiveItems.isLeft == true)                 
                {
                    AmmoManager.instance.AddAmmo(item, interactiveItems);
                }
                else if (AmmoManager.instance != null)
                {
                    AmmoManager.instance.AddAmmo(item);
                }

                foreach (Item i in items)                                               //Return here if ammo is exist in the list
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

            if (item == activeItem)
            {
                activeItem = null;
                _activeIcon.sprite = _defaultActiveIcon;
                itemIsActive = false;

            }
            else
            {
                activeItem = null; //temporary solution
                _activeIcon.sprite = _defaultActiveIcon;
                itemIsActive = false;
            }

            GameObject newObject = Instantiate(dropPrefab, new Vector3(_itemDropPosition.transform.position.x, _itemDropPosition.transform.position.y, _itemDropPosition.transform.position.z), Quaternion.identity);
            newObject.transform.localScale = new Vector3(item.scale, item.scale, item.scale);

            if (item.isAmmo == true)
            {
                InteractiveItems interactiveItems = newObject.GetComponent<InteractiveItems>();         //Give left ammo amount to the ammo object
                interactiveItems.isLeft = true;
                interactiveItems.leftAmount = AmmoManager.instance.ammoArray[item.AmmoType];
                AmmoManager.instance.ammoArray[item.AmmoType] = 0;
            }

            items.Remove(item);

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


            if (activeItem.isWeapon == true && _equipPrefab == null)
            {
                _equipPrefab = Instantiate(activeItem.prefab, _equipmentPos);
                Destroy(_equipPrefab.GetComponent<Rigidbody>());
                AmmoManager.instance.UseAmmo(item);

                /*
                if (AmmoManager.instance.ammoArray[item.AmmoType] >= 0)
                {
                    Debug.Log(AmmoManager.instance.ammoArray[item.AmmoType]);
                    int clipsize = item.AmmoClipSize;
                    AmmoManager.instance.AmmoClipSize(clipsize);
                }
                else
                {
                    Debug.Log("NO AMMO");
                }*/

            }
            else if (activeItem.isWeapon == true)
            {
                Destroy(_equipPrefab);
                _equipPrefab = Instantiate(activeItem.prefab, _equipmentPos);
                Destroy(_equipPrefab.GetComponent<Rigidbody>());
                AmmoManager.instance.UseAmmo(item);
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

        private void CheckActiveItemAmmo()
        {
            if (activeItem != null && AmmoManager.instance != null)
            {
                if (activeItem.AmmoType == AmmoManager.instance.currentUsingAmmoType)
                {
                    string clipAmmo = AmmoManager.instance.currentAmmoClipCount.ToString();
                    string totalAmmo = AmmoManager.instance.ammoArray[AmmoManager.instance.currentUsingAmmoType].ToString();
                    ammoText.text = clipAmmo + "/"+ totalAmmo;
                }
            }
            else
            {
                ammoText.text = "N/A";
            }

        }


    }
}