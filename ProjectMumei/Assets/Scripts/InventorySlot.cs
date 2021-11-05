using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private Item _item;
    public Image icon;
    private Button button;
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private Transform _itemDropPosition;

    private void Start()
    {

        button = gameObject.GetComponentInChildren<Button>();
        button.interactable = false;
    }

    public void AddItem(Item newItem)
    {
        _item = newItem;
        icon.sprite = _item.icon;
        icon.enabled = true;
        _itemPrefab = _item.prefab;
        button.interactable = true;
        Debug.Log("Get Item Prefab" + _itemPrefab);
    }

    public void ClearSlot()
    {
        _item = null;
        icon.sprite = null;
        icon.enabled = false;
        button.interactable = false;
        Debug.Log("Drop Item" + _itemPrefab);
    }
    public void OnMouseRightClickRemove()
    {
        ItemInventory.instance.RemoveItem(_item);

    }
}