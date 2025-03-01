using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private InventoryUI _inventoryUI;
    [SerializeField] private Transform _slotTransform;
    [SerializeField] private ItemUI _slotPrefab;

    private void OnEnable()
    {
        _inventory.OnInventoryUpdated += UpdateUI;
    }

    private void OnDisable()
    {
        _inventory.OnInventoryUpdated -= UpdateUI;
    }

    [ContextMenu("UpdateUI")]
    public void UpdateUI()
    {
        foreach (Transform child in _slotTransform)
        {
            Destroy(child.gameObject);
        }

        List<ItemDataSO> items = _inventory.GetAllItems();
        for (int i = 0; i < items.Count; i++)
        {
            ItemUI slotGO = Instantiate(_slotPrefab, _slotTransform);
            slotGO.Initialize(items[i], i, _inventoryUI);            
        }
    }

    public void SwapItem(int indexA, int indexB)
    {
        List<ItemDataSO> items = _inventory.GetAllItems();
        (items[indexA], items[indexB]) = (items[indexB], items[indexA]);
        UpdateUI();
    }
}
