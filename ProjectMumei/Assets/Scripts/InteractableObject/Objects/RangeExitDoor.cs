using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem;
using AudioManagement;

public class RangeExitDoor : InteractableObject
{
    [SerializeField] Interactable _interactable;

    public void Start()
    {

    }
    public override void InteractAction()
    {
        if(_interactable.locked == true)
        {
            if(ItemInventory.instance.activeItem != null && ItemInventory.instance.activeItem.isKey == true &&
                ItemInventory.instance.activeItem.keyIndex == _interactable.keyIndex)
            {
                Debug.Log("Door Unlocked");
                AudioManager.instance.PlaySFX("DoorUnlocked");
                _interactable.locked = false;
                return;
            }
           
            AudioManager.instance.PlaySFX("DoorLocked");
            Debug.Log("Door Locked");
        }
        else
        {
            AudioManager.instance.PlaySFX("DoorOpened");
            GameManager.instance.LoadNexLevel();
        }
    }

}
