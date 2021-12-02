using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem;
using AudioManagement;

public class Flashlight : MonoBehaviour
{
    private Light _light;
    private bool _isOn;

    private void Start()
    {
        _light = gameObject.GetComponentInChildren<Light>();
        _isOn = false;
    }
    private void Update()
    {
        LightOnOff();
    }

    void LightOnOff()
    {
        if (ItemInventory.instance.itemIsActive)
        {
            if (Input.GetButtonDown("Fire1") && ItemInventory.instance != null && ItemInventory.instance.bagIsOpen != true && ItemInventory.instance.activeItem.name == "Item_Flashlight")
            {
            
                AudioManager.instance.PlaySFX("Flashlight");
                    if (_isOn == false)
                    {
                        _light.enabled = true;
                        _isOn = true;
                    }
                    else
                    {
                        _light.enabled = false;
                        _isOn = false;
                    }
            }
        }
    }
        
}

