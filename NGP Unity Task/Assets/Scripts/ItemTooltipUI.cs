using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemTooltipUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TextMeshProUGUI _itemNameText;
    [SerializeField] private TextMeshProUGUI _itemDescriptionText;
    [SerializeField] private TextMeshProUGUI _itemDamageText;
    [SerializeField] private TextMeshProUGUI _itemResistanceText;
    [SerializeField] private Button _equipButton;
    [SerializeField] private Button _dropButton;
    [SerializeField] private CanvasGroup _canvasGroup;
    private bool _isCursorOverTooltip = false;

    private ItemDataSO _currentItem;
    private Inventory _inventory;

    public bool IsCursorOverTooltip { get => _isCursorOverTooltip; set => _isCursorOverTooltip = value; }

    private void Start()
    {
        //Equip and drop button functionality
    }

    private void Awake()
    {
        _inventory = FindObjectOfType<Inventory>();
        HideTooltip();
    }

    public void ShowTooltip(ItemDataSO item, Vector2 position)
    {
        if (_canvasGroup.alpha == 1) return;

        _currentItem = item;
        _itemNameText.text = item.itemName;
        _itemDescriptionText.text = item.itemDescription;
        _itemDamageText.text = item.damage.ToString();
        _itemResistanceText.text = item.resistance.ToString();
        transform.position = position;
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
    }

    public void HideTooltip()
    {
        if (_isCursorOverTooltip) return;
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _isCursorOverTooltip = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       _isCursorOverTooltip = false;
        HideTooltip();
    }
}
