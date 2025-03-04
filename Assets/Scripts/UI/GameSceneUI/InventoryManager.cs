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
        foreach (var item in items)
        {

            if (item.itemName == newItem.itemName) // 既存アイテムがある場合
            {
                if (item.amount < item.maxStack)
                {
                    item.amount++;
                    Debug.Log("既存アイテム " + item.itemName + " のスタック増加: " + item.amount);
                    // UIを更新
                    FindObjectOfType<InventoryUI>().UpdateUI(); return true;
                }
                else
                {
                    continue; // スタックが満杯なら次へ
                }
            }
            if (items.Count < maxSlots)
            {
                items.Add(newItem);
                Debug.Log("アイテム追加: " + newItem.itemName);

                // UIを更新
                FindObjectOfType<InventoryUI>().UpdateUI();

                return true;
            }
            Debug.Log("インベントリ満杯！");
            return false;
        }

        // 新規アイテムを追加
        if (items.Count < maxSlots)
        {
            newItem.amount = 1; // 初回は1個
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