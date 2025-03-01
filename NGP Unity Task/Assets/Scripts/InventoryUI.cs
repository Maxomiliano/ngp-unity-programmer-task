using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Transform _slotTransform;
    [SerializeField] private GameObject _slotPrefab;

    public void UpdateUI()
    {
        foreach (Transform child in _slotTransform)
        {
            Destroy(child.gameObject);
        }

        List<ItemDataSO> items = _inventory.GetAllItems();
        for (int i = 0; i < items.Count; i++)
        {
            GameObject slotGO = Instantiate(_slotPrefab, _slotTransform);
            ItemUI slot = slotGO.GetComponent<ItemUI>();
            slot.Initialize(items[i], i, _inventory);            
        }
    }

    public void SwapItem(int indexA, int indexB)
    {
        List<ItemDataSO> items = _inventory.GetAllItems();
        (items[indexA], items[indexB]) = (items[indexB], items[indexA]);
        UpdateUI();
    }
}
