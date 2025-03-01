using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Armor,
    Consumable,
    Material,
    Trinket
}

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/ItemData")]
public class ItemDataSO : ScriptableObject
{
    //public GameObject itemPrefab;
    public string itemName;
    public ItemType type;
    public Sprite itemIcon;
    public string itemDescription;
    public int damage;
    public int resistance;

    /*
    public void Use() 
    { 
        //Switch case en funcion del tipo de item
    }

    [ContextMenu("AddItem")]
    public void AddItem()
    {
        FindFirstObjectByType<Inventory>().AddItem(this);
    }
    */
}
