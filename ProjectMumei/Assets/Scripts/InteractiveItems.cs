using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveItems : MonoBehaviour
{
    public Item item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Pickup()
    {
        Debug.Log("Item" + item.name + "pickedup");
        ItemInventory.instance.Add(item);
    }
}
