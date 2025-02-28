using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int _maxSlots = 10;
    private List<ItemDataSO> _items = new List<ItemDataSO>();

    public bool AddItem(ItemDataSO item)
    {
        if (_items.Count >= _maxSlots)
        {
            Debug.Log("Inventory full");
            return false;
        }
        _items.Add(item);
        return true;
    }
}
