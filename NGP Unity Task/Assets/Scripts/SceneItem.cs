using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SceneItem : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemDataSO _itemData;

    [ContextMenu("Interact")]
    public void Interact()
    {
        if (Inventory.Instance.AddItem(_itemData))
        {
            Destroy(gameObject);
        }
    }
}
