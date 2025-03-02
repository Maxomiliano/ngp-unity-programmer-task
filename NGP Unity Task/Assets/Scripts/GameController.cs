using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] Button _saveButton;
    [SerializeField] Button _loadButton;

    private void Start()
    {
        _saveButton.onClick.AddListener(() => Inventory.Instance.SaveInventory());
        _loadButton.onClick.AddListener(()=>  Inventory.Instance.LoadInventory());
    }
}
