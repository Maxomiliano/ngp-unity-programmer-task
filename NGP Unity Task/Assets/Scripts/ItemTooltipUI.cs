using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltipUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _itemNameText;
    [SerializeField] private TextMeshProUGUI _itemDescriptionText;
    [SerializeField] private TextMeshProUGUI _itemStatsText;
    [SerializeField] private Button _equipButton;
    [SerializeField] private Button _dropButton;

    private ItemDataSO _currentItem;
    private Inventory _inventory;
}
