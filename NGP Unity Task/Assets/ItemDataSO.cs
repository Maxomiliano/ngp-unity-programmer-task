using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/ItemData")]
public class ItemDataSO : ScriptableObject
{
    public GameObject itemPrefab;
    public string itemName;
    public enum ItemType {Weapon, Armor, Tool, Material };
    public Sprite itemIcon;
}
