using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    [Header("Core")]
    new public string name = "New Item";
    public Sprite icon = null;
    public GameObject prefab;
    public string description;
    public float scale;

    [Header("Weapon")]
    public bool isWeapon;
    public int weaponIndex;

    [Header("Ammo")]
    public bool isAmmo;
    public int AmmoType;
    public int MaxAmmoAmount;
    public int CurrentAmmoAmount;
    public bool isused = false;
    public int AmmoAmountLeft;

    [Header("Key")]
    public bool isKey;
    public int keyIndex;


}
