using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltipUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _itemNameText;
    [SerializeField] private TextMeshProUGUI _itemDescriptionText;
    [SerializeField] private TextMeshProUGUI _itemDamageText;
    [SerializeField] private TextMeshProUGUI _itemResistanceText;
    [SerializeField] private Button _equipButton;
    [SerializeField] private Button _dropButton;

    private ItemDataSO _currentItem;
    private Inventory _inventory;

    private void Start()
    {
        //Equip and drop button functionality
    }

    private void Awake()
    {
        _inventory = FindObjectOfType<Inventory>();
        gameObject.SetActive(false);
    }

    public void ShowTooltip(ItemDataSO item, Vector2 position)
    {
        _currentItem = item;
        _itemNameText.text = item.itemName;
        _itemDescriptionText.text = item.itemDescription;
        _itemDamageText.text = item.damage.ToString();
        _itemResistanceText.text = item.resistance.ToString();
        transform.position = position;
        gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }
}
