using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class EquipmentSlot : MonoBehaviour
{
    [SerializeField] ItemType _itemType;
    [SerializeField] EquipmentSlotUI _equippedPrefab;

    private EquipmentSlotUI _equippedSlotUI;

    public ItemType Type { get => _itemType; }

    public void SetItemSlotValue(ItemDataSO item)
    {
        if (item != null)
        {
            //Mostrar contenido del item
            _equippedSlotUI = Instantiate(_equippedPrefab, transform);
            _equippedSlotUI.Initialize(item);
        }
        else
        {
            if (_equippedSlotUI != null)
            {
                //Vaciar contenido
                Destroy(_equippedSlotUI.gameObject);
            }
        }
    }
}

