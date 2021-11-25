using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class InteractiveItems : MonoBehaviour
    {
        public Item item;
        public bool isUsed;

        private void Start()
        {
            isUsed = false;
        }

        void Pickup()
        {
            if(item.isAmmo == true)
            {
                InitializeAmmo();
            }
            ItemInventory.instance.Add(item);
        }

        private void InitializeAmmo()
        {
            if (item.isused == false)
            {
                item.CurrentAmmoAmount = item.MaxAmmoAmount;
            }else
            {
                item.CurrentAmmoAmount = item.AmmoAmountLeft;
            }
        }
    }
}