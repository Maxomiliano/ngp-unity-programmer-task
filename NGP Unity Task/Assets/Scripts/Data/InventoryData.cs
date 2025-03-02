using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryData
{
    public List<string> itemsIDs = new List<string>();
    //public Dictionary<ItemType, string> equippedItems = new Dictionary<ItemType, string>();
    public List<EquippedItemData> equippedItems = new List<EquippedItemData>();
}

[System.Serializable]
public class EquippedItemData
{
    public ItemType itemType;
    public string itemID;
}
