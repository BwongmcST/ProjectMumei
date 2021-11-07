using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class ItemPickup : MonoBehaviour
    {
        [SerializeField] private PlayerRaycasting _playerRaycasting;

        void Update()
        {
            PickUp();
        }

        void PickUp()
        {

            if (Input.GetKeyDown(KeyCode.E) && _playerRaycasting.interactiveItemHit.collider != null && _playerRaycasting.interactiveItemHit.collider.gameObject.tag == "Interactable")
            {
                Debug.Log("Picking up an item");
                _playerRaycasting.interactiveItemHit.transform.SendMessage("Pickup");   //Called void ItemPickup() in InteractiveItems

                if (ItemInventory.instance.bagIsFull == false)
                {
                    Destroy(_playerRaycasting.interactiveItemHit.collider.gameObject);
                }
            }
        }

    }

}
