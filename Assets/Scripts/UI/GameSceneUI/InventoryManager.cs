using System.Collections.Generic;
using UnityEngine;

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
}