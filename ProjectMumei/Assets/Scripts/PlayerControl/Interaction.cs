using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem;

public class Interaction : MonoBehaviour
{
    [SerializeField] private PlayerRaycasting _playerRaycasting;

    void Update()
    {
        Interact();

        void PickUp()
        {
            Debug.Log("Picking up an item");
            _playerRaycasting.interactiveItemHit.transform.SendMessage("Pickup");   //Called void ItemPickup() in hitted target (InteractiveItems)

            if (ItemInventory.instance.bagIsFull == false)
            {
                Destroy(_playerRaycasting.interactiveItemHit.collider.gameObject);
            }
        }

        void InteractableObject()
        {
            _playerRaycasting.interactiveItemHit.transform.SendMessage("InteractAction"); //Called void InteractAction() in hitted target (InteractiveObjects)
        }


        void Interact()
        {
            if (Input.GetKeyDown(KeyCode.E) && _playerRaycasting.interactiveItemHit.collider != null && _playerRaycasting.interactiveItemHit.collider.gameObject.tag == "Item")
            {
                PickUp();
            }

            if (Input.GetKeyDown(KeyCode.E) && _playerRaycasting.interactiveItemHit.collider != null && _playerRaycasting.interactiveItemHit.collider.gameObject.tag == "Interactable")
            {
                InteractableObject();
            }

        }
    }
}
