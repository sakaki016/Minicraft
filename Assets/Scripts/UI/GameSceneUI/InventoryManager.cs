using System;
using System.Collections.Generic;
using UnityEngine;

/*-------------------------↓中西作業↓-------------------------*/
[System.Serializable]
public struct StartingItem
{
    public ItemScriptableObject itemData;
    public int amount;
    public Vector2Int position; // Inventory position
}


public class InventoryManager : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public int maxSlots = 36; // スロット数（例えば9×4）

    public bool AddItem(Item newItem)
    {
        if (items.Count < maxSlots)
        {
            items.Add(newItem);
            return true;
        }
        return false; // インベントリが満杯
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }


    /*-------------------------↓中西作業↓-------------------------*/
    public List<StartingItem> startingItems;
    private void Start()
    {
        foreach (StartingItem si in startingItems)
        {
            AddItem(new Item(si.itemData, si.amount), si.position);
        }
    }

    public bool AddItem(Item item, Vector2Int position)
    {
        if (items.Count < maxSlots)
        {
            items.Add(item);
            return true;
        }
        return false; // インベントリが満杯
    }
    /*-------------------------↑中西作業↑-------------------------*/
}