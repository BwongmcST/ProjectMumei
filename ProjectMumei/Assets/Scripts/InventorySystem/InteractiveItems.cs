using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class InteractiveItems : MonoBehaviour
    {
        public Item item;
        private GameObject _gameObject;
        public bool isLeft;
        public int leftAmount;


        private void Start()
        {
            _gameObject = transform.gameObject;
        }
        void Pickup()
        {
            if(item.isAmmo == true)
            {
                InitializeAmmo();
            }
            ItemInventory.instance.Add(item,_gameObject);
        }

        private void InitializeAmmo()
        {
                item.CurrentAmmoAmount = item.MaxAmmoAmount;
        }
    }
}