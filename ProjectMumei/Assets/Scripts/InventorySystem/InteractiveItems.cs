using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class InteractiveItems : MonoBehaviour
    {
        public Item item;

        void Pickup()
        {
            ItemInventory.instance.Add(item);
            if(item.isAmmo == true)
            {
                InitializeAmmo();
            }
        }

        private void InitializeAmmo()
        {
            item.CurrentAmmoAmount = item.MaxAmmoAmount;
            Debug.Log(item.CurrentAmmoAmount);
            if (item.isused == true)
            {
                item.CurrentAmmoAmount = item.AmmoAmountLeft;
            }
        }
    }
}