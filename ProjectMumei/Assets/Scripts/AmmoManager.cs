using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem;

public class AmmoManager : MonoBehaviour
{
    public List<Item> Ammo = new List<Item>();
    [SerializeField] private Item _currentUsingAmmo;
    [SerializeField] private int _currentUsingAmmoAmount;

    private static AmmoManager _instance;
    public static AmmoManager instance
    {
        get { return _instance; }
    }

     private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }

        Ammo = new List<Item>();
    }

    private void OnDestroy()
    {
        _instance = null;
    }

    public void AddAmmo(Item item)
    {
        foreach (Item i in Ammo)
        {
            if (i.isAmmo == true && i.AmmoType == item.AmmoType)
            {
                if(_currentUsingAmmo != null && _currentUsingAmmo.AmmoType == i.AmmoType)                     //Return the ammount ammoun to the ammo item
                {
                    i.CurrentAmmoAmount = _currentUsingAmmoAmount;
                }
                i.CurrentAmmoAmount += item.MaxAmmoAmount;
                return;
            }
        }
        Ammo.Add(item);
    }

    public void AmmoDrop(Item item)
    {
    
    }

    public int GetCurrentAmmo(Item item)
    {
        int currentAmmo = 0;
        foreach (Item i in Ammo)
        {
            if (i.isAmmo == true && i.AmmoType == item.AmmoType)
            {
                currentAmmo = i.CurrentAmmoAmount;
                break;
            }
        }
        return (currentAmmo);
    }


    public void UseAmmo()
    {
        foreach (Item i in Ammo)
        {
            if (i.isAmmo == true && i.AmmoType == ItemInventory.instance.activeItem.weaponIndex)
            {
                _currentUsingAmmo = i;
                Debug.Log(_currentUsingAmmo);
                break;
            }
        }
    }

    public void FireAmmo(int a)
    {
        if (_currentUsingAmmo != null)
        {
            _currentUsingAmmo.CurrentAmmoAmount -= a;
            _currentUsingAmmoAmount = _currentUsingAmmo.CurrentAmmoAmount;
        }

    }


}
