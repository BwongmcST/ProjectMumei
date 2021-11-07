using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycasting : MonoBehaviour
{
    [SerializeField] private float _pickupDistance = 7;
    public RaycastHit interactiveItemHit;

    void Update()
    {
        Raycasting();
        //IntertactingObject();
    }

    void Raycasting()
    {
        Debug.DrawRay(this.transform.position, this.transform.forward * _pickupDistance, Color.red);
        Physics.Raycast(this.transform.position, this.transform.forward, out interactiveItemHit, _pickupDistance);
        
    }

  /*  void IntertactingObject()
    {
        if(Input.GetKeyDown(KeyCode.E) && _interactiveItemHit.collider != null && _interactiveItemHit.collider.gameObject.tag == "Interactable")
        {
            Debug.Log("Interactable");
        }
    }*/


}
