using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase Instance { get; private set; }
    [SerializeField] private List<ItemDataSO> allItems = new List<ItemDataSO>();
    private Dictionary<string, ItemDataSO> itemDictionary = new Dictionary<string, ItemDataSO>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeDatabase();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeDatabase()
    {
        foreach (ItemDataSO item in allItems)
        {
            if (!itemDictionary.ContainsKey(item.ID))
            {
                itemDictionary.Add(item.ID, item);
            }
        }
    }

    public ItemDataSO GetItemByID(string id)
    {
        if(itemDictionary.TryGetValue(id, out ItemDataSO item))
        {
            return item;
        }
        return null;
    }
}

