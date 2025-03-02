using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryData
{
    public List<string> itemsIDs = new List<string>();
    public Dictionary<ItemType, string> equippedItems = new Dictionary<ItemType, string>();
}
