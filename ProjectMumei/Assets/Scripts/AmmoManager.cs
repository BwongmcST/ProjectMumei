using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem;

public class AmmoManager : MonoBehaviour
{
    public List<Item> Ammo = new List<Item>();
    public int[] ammoArray;
    public bool ammoClipIsOut;
    public bool allAmmoOut;
   
    public int currentUsingAmmoType;
    public bool isGunEquiped;
    public int currentAmmoClipCount;
    public int thisAmmoClipSize;

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
        //ammoArray[currentUsingAmmoType] -= a;
        currentAmmoClipCount -= a; 

    }

    public void CheckAmmoIsOut()
    {
        if(currentAmmoClipCount <= 0)
        {
            ammoClipIsOut = true;
        }else
        {
            ammoClipIsOut = false;
        }
    }

   public void AmmoClipSize(int i)                       //Get weapon ammo capacity
    {
        thisAmmoClipSize = i;
        currentAmmoClipCount = 0;

    }

    public void AmmoReload(int ammoType)
    {
        int ActualAmmoClip = thisAmmoClipSize - 1;  // -1 to avoid extra ammo count in while loop
        while (ammoArray[ammoType] > 0 && currentAmmoClipCount <= ActualAmmoClip)
        {
            ammoArray[ammoType]--;
            currentAmmoClipCount++;
        }
    }

    public void GiveAmmoBackToClip(int ammoType)
    {
        ammoArray[ammoType] += currentAmmoClipCount;
        currentAmmoClipCount = 0;
    }

}
