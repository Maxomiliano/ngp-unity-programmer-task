using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

    [SerializeField] private int _maxSlots = 10;
    private List<ItemDataSO> _items = new List<ItemDataSO>();
    public event Action OnInventoryUpdated;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool AddItem(ItemDataSO item)
    {
        Debug.Log("Objeto a�adido al inventario");
        if (_items.Count >= _maxSlots)
        {
            Debug.Log("Inventory full");
            return false;
        }
        _items.Add(item);
        OnInventoryUpdated?.Invoke();
        return true;
    }

    public void RemoveItem(ItemDataSO item)
    {
        if (_items.Contains(item))
        {
            _items.Remove(item);
        }
    }

    public ItemDataSO GetItem(int index)
    {
        if (index >= 0 && index < _items.Count)
        {
            return _items[index];
        }
        return null;
    }

    public bool Contains(ItemDataSO item)
    {
        return _items.Contains(item);
    }

    public List<ItemDataSO> GetAllItems()
    {
        return _items;
    }

    public void EquipItem(ItemDataSO item)
    {
        
    }

    public void UnequipItem(ItemDataSO item)
    {
        
    }

    //Metodo para checkear si hay slot vacio de la lista de ItemSlots
}
