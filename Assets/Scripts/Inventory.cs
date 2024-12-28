using System;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    public event Action<List<ItemData>> onInventoryChanged;
    private List<ItemData> items = new List<ItemData>();

    public void AddItem(string itemName, Sprite sprite, int count)
    {
        int index = items.FindIndex(item => item.itemName == itemName);
        if (index != -1)
        {
            items[index].count += count; 
        }
        else
        {
            items.Add(new ItemData(itemName, sprite, count)); 
        }
        onInventoryChanged?.Invoke(items); 
    }
}

