using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class InventoryController : MonoBehaviour
    {
        public bool inventoryIsOpen = false;
        [SerializeField] private GameObject _inventoryCanvas;
        // Start is called before the first frame update

        void Start()
        {
            _inventoryCanvas.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            InventoryOnOff();
        }
        void InventoryOnOff()
        {
            if (Input.GetKeyDown(KeyCode.B) && inventoryIsOpen == false)
            {
                _inventoryCanvas.SetActive(true);
                inventoryIsOpen = true;
                ItemInventory.instance.bagIsOpen = inventoryIsOpen;
                Cursor.lockState = CursorLockMode.None;
                //Debug.Log("None");
            }
            else if (Input.GetKeyDown(KeyCode.B) && inventoryIsOpen == true)
            {
                _inventoryCanvas.SetActive(false);
                inventoryIsOpen = false;
                ItemInventory.instance.bagIsOpen = inventoryIsOpen;
                Cursor.lockState = CursorLockMode.Locked;
                //Debug.Log("Locked");
            }
        }
    }
}