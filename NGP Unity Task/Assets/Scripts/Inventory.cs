using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

    [SerializeField] private int _maxSlots = 10;

    private List<ItemDataSO> _items = new List<ItemDataSO>();
    private Dictionary<ItemType, ItemDataSO> _equippedSlots = new Dictionary<ItemType, ItemDataSO>()
    {
        { ItemType.Weapon, null },
        { ItemType.Armor, null },
        { ItemType.Trinket, null}
    };
    public Dictionary<ItemType, ItemDataSO> EquippedSlots => _equippedSlots;

    public bool IsItemEquipped { get => _isItemEquipped; set => _isItemEquipped = value; }

    public event Action OnInventoryUpdated;
    private bool _isItemEquipped;


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
        _items.Add(Instantiate(item));
        OnInventoryUpdated?.Invoke();
        return true;
    }

    public void RemoveItem(ItemDataSO item)
    {
        if (_items.Contains(item))
        {
            _items.Remove(item);
        }
        OnInventoryUpdated?.Invoke();
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
        if (_equippedSlots.ContainsKey(item.type))
        {
            if (_equippedSlots[item.type] != null)
            {
                var oldItem = _equippedSlots[item.type];
                AddItem(oldItem);
            }
            _equippedSlots[item.type] = item;
            RemoveItem(item);
        }
        IsItemEquipped = false;
        OnInventoryUpdated?.Invoke();
    }

    public void UnequipItem(ItemDataSO item)
    {
        if (_equippedSlots.ContainsKey(item.type))
        {
            if (_equippedSlots[item.type] != null)
            {
                AddItem(item);
                _equippedSlots[item.type] = null;
            }
        }
        IsItemEquipped = false;
        OnInventoryUpdated?.Invoke();
    }

    public void ConsumeItem(ItemDataSO item)
    {
        if (item.type == ItemType.Consumable)
        {
            //Action
            RemoveItem(item);
            OnInventoryUpdated?.Invoke();
        }
    }
}
