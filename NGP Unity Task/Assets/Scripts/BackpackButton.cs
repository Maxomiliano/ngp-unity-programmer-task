using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackButton : MonoBehaviour
{
    [SerializeField] GameObject _inventoryUI;
    [SerializeField] Button _backpackButton;
    [SerializeField] Button _closeInventoryButton;

    private bool _isOpen = false;

    public bool IsOpen { get => _isOpen; set => _isOpen = value; }

    void Start()
    {
        _inventoryUI.SetActive(false);
        _backpackButton.onClick.AddListener(ToggleInventoryPanel);
        _closeInventoryButton.onClick.AddListener(CloseInventoryPanel);
    }

    private void ToggleInventoryPanel()
    {
        _isOpen = !_isOpen;
        _inventoryUI.SetActive(_isOpen);
    }

    private void CloseInventoryPanel()
    { 
        _isOpen = false;
        _inventoryUI.SetActive(false);
    }
}
