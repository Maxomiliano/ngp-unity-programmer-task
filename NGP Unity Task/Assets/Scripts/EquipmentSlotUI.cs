using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlotUI : MonoBehaviour
{
    //[SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Image _slotIcon;
    [SerializeField] private TextMeshProUGUI _slotText;
    private ItemDataSO _itemData;

    public void Initialize(ItemDataSO item)
    {
        _itemData = item;
        _slotIcon.sprite = item.itemIcon;
        _slotText.text = item.name;
    }
}
