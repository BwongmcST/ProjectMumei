using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycasting : MonoBehaviour
{
    [SerializeField]
    private float _pickupDistance = 5;

    private RaycastHit _itemHit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        raycasting();
        intertactingObject();
    }

    void raycasting()
    {
        Debug.DrawRay(this.transform.position, this.transform.forward * _pickupDistance, Color.red);
        Physics.Raycast(this.transform.position, this.transform.forward, out _itemHit, _pickupDistance);
        
    }

    void intertactingObject()
    {
        if(Input.GetKeyDown(KeyCode.E) && _itemHit.collider != null && _itemHit.collider.gameObject.tag == "Interactable")
        {
            Debug.Log("Interactable");
        }
    }


}
