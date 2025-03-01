using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class EquipmentSlot : MonoBehaviour
{
    [SerializeField] ItemType _itemType;
    [SerializeField] GameObject _equippedObject;

    public ItemType Type { get => _itemType; }

    public void SetItemSlotValue(ItemDataSO item)
    {
        if (item != null)
        {
            //Mostrar contenido del item
            Instantiate(_equippedObject, transform);
        }
        else
        {
            //Vaciar contenido
        }
    }
}

