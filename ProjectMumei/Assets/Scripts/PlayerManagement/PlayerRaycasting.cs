using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerManagement
{
    public class PlayerRaycasting : MonoBehaviour
    {
        [SerializeField] private float _pickupDistance = 7;
        public RaycastHit interactiveItemHit;
        [SerializeField] private bool rayCastTest = false; //for testing only

        void Update()
        {
            Raycasting();
            //IntertactingObject();
        }

        void Raycasting()
        {
            Debug.DrawRay(this.transform.position, this.transform.forward * _pickupDistance, Color.red);
            Physics.Raycast(this.transform.position, this.transform.forward, out interactiveItemHit, _pickupDistance);
            if (rayCastTest == true)
            {
               Debug.Log(interactiveItemHit);
            }

        }

        /*  void IntertactingObject()
          {
              if(Input.GetKeyDown(KeyCode.E) && _interactiveItemHit.collider != null && _interactiveItemHit.collider.gameObject.tag == "Interactable")
              {
                  Debug.Log("Interactable");
              }
          }*/


    }
}