using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentSlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image _slotIcon;
    [SerializeField] private TextMeshProUGUI _slotText;
    private ItemTooltipUI _slotTooltip;
    private ItemDataSO _itemData;

    public void Initialize(ItemDataSO item)
    {
        if (item != null)
        {
            _itemData = item;
            _slotIcon.sprite = item.itemIcon;
            _slotText.text = item.name;
            _slotTooltip = FindObjectOfType<ItemTooltipUI>();
        }
        else
        { 
            ClearSlot();
        }
    }

    public void ClearSlot()
    {
        _itemData = null;
        _slotIcon.sprite = null;
        _slotText.text = null;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _slotTooltip.ShowTooltip(_itemData, transform.position);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StartCoroutine(DelayedHideTooltip());
    }

    private IEnumerator DelayedHideTooltip()
    {
        yield return new WaitForEndOfFrame();
        if (!_slotTooltip.IsCursorOverTooltip)
        {
            _slotTooltip.HideTooltip();
        }
    }
}
