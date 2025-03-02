using System;
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
        Debug.Log("Objeto añadido al inventario");
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

    public void SaveInventory()
    {
        InventoryData data = new InventoryData();
        data.itemsIDs = _items.Select(i => i.ID).ToList();
        foreach (var kvp in _equippedSlots)
        {
            if (kvp.Value != null)
            {
                //data.equippedItems[kvp.Key] = kvp.Value.ID;
                EquippedItemData equippedData = new EquippedItemData
                {
                    itemType = kvp.Key,
                    itemID = kvp.Value.ID
                };
                data.equippedItems.Add(equippedData);
                Debug.Log($"Saving equipped item: {kvp.Key} -> {kvp.Value.ID}");
            }
        }

        string json = JsonUtility.ToJson(data, true);
        PlayerPrefs.SetString("InventoryData", json);
        PlayerPrefs.Save();
    }

    public void LoadInventory()
    {
        if (PlayerPrefs.HasKey("InventoryData"))
        {
            string json = PlayerPrefs.GetString("InventoryData");
            InventoryData data = JsonUtility.FromJson<InventoryData>(json);

            Debug.Log("Loading Inventory: " + json);

            _items.Clear();
            _equippedSlots = new Dictionary<ItemType, ItemDataSO>()
            {
                { ItemType.Weapon, null },
                { ItemType.Armor, null },
                { ItemType.Trinket, null}
            };

            foreach (string itemID in data.itemsIDs)
            {
                ItemDataSO item = ItemDatabase.Instance.GetItemByID(itemID);
                {
                    if (item != null)
                    {
                        _items.Add(item);
                    }
                }
            }
            foreach (var equippedItem in data.equippedItems)
            {
                Debug.Log($"Trying to equip {equippedItem.itemID} to {equippedItem.itemType}");
                ItemDataSO item = ItemDatabase.Instance.GetItemByID(equippedItem.itemID);
                if (item != null)
                {
                    _equippedSlots[equippedItem.itemType] = item;
                    Debug.Log($"Successfully loaded {item.ID} into {equippedItem.itemType}");
                }
                else
                {
                    Debug.LogError($"Failed to load item with ID {equippedItem.itemID}");
                }
            }
            OnInventoryUpdated?.Invoke();
        }
    }
}
