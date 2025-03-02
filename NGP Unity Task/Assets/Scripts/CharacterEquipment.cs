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
        foreach (EquipmentSlot equipmentSlot in _equipmentSlotList)
        {
            ItemDataSO slot = Inventory.Instance.EquippedSlots[equipmentSlot.Type];
            equipmentSlot.SetItemSlotValue(slot);
        }
    }
}
