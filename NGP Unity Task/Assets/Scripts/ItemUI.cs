using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler, IDropHandler
//IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Image _itemIcon;
    private ItemDataSO _itemData;
    private int _index;
    private InventoryUI _inventoryUI;
    private Transform _parentTransform;



    public void Initialize(ItemDataSO item, int index, InventoryUI inventoryUI)
    {
        _itemData = item;
        _index = index;
        _inventoryUI = inventoryUI;
        _itemIcon.sprite = item.itemIcon;
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _parentTransform = transform.parent;
        transform.SetParent(transform.root);
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
    }

    public void OnDrop(PointerEventData eventData)
    {
        ItemUI droppedItem = eventData.pointerDrag.GetComponent<ItemUI>();
        if (droppedItem != null)
        {
            _inventoryUI.SwapItem(_index, droppedItem._index);
        }
    }
}
