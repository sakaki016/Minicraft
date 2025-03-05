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
        Debug.Log("AddItem 呼び出し: " + newItem.itemName);

        // 既存アイテムを探し、スタックできる場合はスタック
        foreach (var item in items)
        {
            if (item.itemName == newItem.itemName) // 同じアイテムがあるかチェック
            {
                if (item.amount < item.maxStack)
                {
                    item.amount++;
                    Debug.Log("既存アイテム " + item.itemName + " のスタック増加: " + item.amount);
                    FindObjectOfType<InventoryUI>().UpdateUI();
                    return true; // アイテムを追加できたので終了
                }
            }
        }

        // 既存のアイテムに追加できなかった場合、新規スロットに追加
        if (items.Count < maxSlots)
        {
            Item newItemCopy = new Item
            {
                itemName = newItem.itemName,
                icon = newItem.icon,
                maxStack = newItem.maxStack,
                amount = 1, // 新規追加なので1個
                itemPrefab = newItem.itemPrefab
            };

            items.Add(newItemCopy);
            Debug.Log("新規アイテム追加: " + newItem.itemName);
            FindObjectOfType<InventoryUI>().UpdateUI();
            return true;
        }

        Debug.Log("インベントリ満杯！");
        return false; // スロットが満杯で追加できなかった場合
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }


}