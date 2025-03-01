using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ItemUI : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Image _itemIcon;
    [SerializeField] private TextMeshProUGUI _text;
    private ItemDataSO _itemData;
    private ItemTooltipUI _tooltipUI;
    private int _index;
    private InventoryUI _inventoryUI;
    private Transform _parentTransform;



    public void Initialize(ItemDataSO item, int index, InventoryUI inventoryUI)
    {
        _itemData = item;
        _index = index;
        _inventoryUI = inventoryUI;
        _itemIcon.sprite = item.itemIcon;
        _text.text = item.name;
        _canvasGroup = GetComponent<CanvasGroup>();
        _tooltipUI = FindObjectOfType<ItemTooltipUI>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _parentTransform = transform.parent;
        _canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(_parentTransform);
        _canvasGroup.blocksRaycasts = true;
        LayoutRebuilder.ForceRebuildLayoutImmediate(transform.parent.GetComponent<RectTransform>());
    }

    public void OnDrop(PointerEventData eventData)
    {
        ItemUI droppedItem = eventData.pointerDrag.GetComponent<ItemUI>();
        if (droppedItem != null)
        {
            _inventoryUI.SwapItem(_index, droppedItem._index);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _tooltipUI.ShowTooltip(_itemData, transform.position);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StartCoroutine(DelayedHideTooltip());
    }

    private IEnumerator DelayedHideTooltip()
    {
        yield return new WaitForSeconds(0.1f);
        if (!_tooltipUI.IsCursorOverTooltip)
        {
            _tooltipUI.HideTooltip();
        }
    }
}
