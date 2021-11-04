using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private Item _item;

    public Image icon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(Item newItem)
    {
        _item = newItem;
        icon.sprite = _item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        _item = null;
        //icon.sprite = null;
       // icon.enabled = false;
    }
}
