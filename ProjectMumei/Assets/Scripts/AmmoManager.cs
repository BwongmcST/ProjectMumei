using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem;

public class AmmoManager : MonoBehaviour
{
    public List<Item> Ammo = new List<Item>();
    public int[] ammoArray;
    public bool ammoIsOut;
    public int currentUsingAmmoType;
    public bool isGunEquiped;
    private int _ammoClip;

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
            isGunEquiped = false;
        }
    }


    private void Start()
    {
        ammoArray = new int[] { 0, 0, 0, 0, 0 };
    }

    private void Update()
    {
        CheckAmmoIsOut();
    }

    private void OnDestroy()
    {
        _instance = null;
    }

    public void AddAmmo(Item item)
    {
        ammoArray[item.AmmoType] += item.MaxAmmoAmount;
    }

    public void AddAmmo(Item item, InteractiveItems interactiveItems)
    {
        ammoArray[item.AmmoType] += interactiveItems.leftAmount;
    }

    public int GetCurrentAmmo(Item item)
    {
        return ammoArray[item.AmmoType];
    }


    public void UseAmmo(Item item)
    {
        currentUsingAmmoType = item.AmmoType;
    }

    public void FireAmmo(int a)
    {
        Debug.Log("Ammo -1");
        ammoArray[currentUsingAmmoType] -= a;
        //_ammoClip -= a;

    }

    public void CheckAmmoIsOut()
    {
        if(ammoArray[currentUsingAmmoType] <= 0)
        {
            ammoIsOut = true;
        }
        else
        {
            ammoIsOut = false;
        }
    }

   public void AmmoClipSize(int i)
    {
        _ammoClip = i;
    }

}
