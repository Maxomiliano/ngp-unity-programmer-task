using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackButton : MonoBehaviour
{
    [SerializeField] GameObject _inventoryPanel;
    [SerializeField] Button _backpackButton;
    [SerializeField] Button _closeInventoryButton;
    [SerializeField] InventoryUI _inventoryUI;

    private bool _isOpen = false;

    public bool IsOpen { get => _isOpen; set => _isOpen = value; }

    void Start()
    {
        _inventoryPanel.SetActive(false);
        _backpackButton.onClick.AddListener(ToggleInventoryPanel);
        _closeInventoryButton.onClick.AddListener(CloseInventoryPanel);
    }

    private void ToggleInventoryPanel()
    {
        _isOpen = !_isOpen;
        _inventoryPanel.SetActive(_isOpen);
        _inventoryUI.UpdateUI();
    }

    private void CloseInventoryPanel()
    { 
        _isOpen = false;
        _inventoryPanel.SetActive(false);
    }
}
