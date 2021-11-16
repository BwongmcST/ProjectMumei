using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public GameObject prefab;
    public bool isWeapon;
    public int weaponIndex;
    public bool isKey;
    public int keyIndex;
    public string description;
    public float scale;

}
