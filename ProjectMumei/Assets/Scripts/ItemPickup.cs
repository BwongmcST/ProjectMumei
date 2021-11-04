using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private PlayerRaycasting _playerRaycasting;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PickUp();
    }

    void PickUp()
    {

        if (Input.GetKeyDown(KeyCode.E) && _playerRaycasting.interactiveItemHit.collider != null && _playerRaycasting.interactiveItemHit.collider.gameObject.tag == "Interactable")
        {
            //Debug.Log("PickupAnItem");
            _playerRaycasting.interactiveItemHit.transform.SendMessage("Pickup");   //Called void ItemPickup() in InteractiveItems
            
            if (ItemInventory.instance.bagIsFull == false)
            {
                Destroy(_playerRaycasting.interactiveItemHit.collider.gameObject);
            }
        }
    }

}
