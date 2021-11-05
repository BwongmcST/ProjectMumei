using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveItems : MonoBehaviour
{
    public Item item;

    void Pickup()
    {
        Debug.Log("Item" + item.name + "pickedup");
        ItemInventory.instance.Add(item);
    }
}
