using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterEquipment : MonoBehaviour
{
    [SerializeField] List<EquipmentSlot> _equipmentSlotList = new List<EquipmentSlot>();

    private void Start()
    {
        Inventory.Instance.OnInventoryUpdated += Refresh;
    }

    private void OnDestroy()
    {
        Inventory.Instance.OnInventoryUpdated -= Refresh;
    }

    private void Refresh()
    {
        //Actualizar el estado de cada slot
        //El estado puede ser vacío u ocupado
        foreach (EquipmentSlot equipmentSlot in _equipmentSlotList)
        {
            //Por cada equipped slot tengo que determinar si tiene algo o no
            ItemDataSO slot = Inventory.Instance.EquippedSlots[equipmentSlot.Type];
            equipmentSlot.SetItemSlotValue(slot);
        }
    }
}
