using System;
using System.Collections.Generic;
using UnityEngine;


public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    public List<Item> items = new List<Item>();
    public int maxSlots = 45; // 固定スロット数
    public int hotbarSlots = 9; // ホットバーのスロット数

    void Awake()
    {
        Instance = this;
        // 固定スロット方式のため、最初から maxSlots 分のスロットを用意（空は null）
        for (int i = 0; i < maxSlots; i++)
        {
            items.Add(null);

        }
    }

    public bool AddItem(Item newItem)
    {
        Debug.Log("AddItem 呼び出し: " + newItem.itemName);

        // 既存スロットで同じアイテムがあればスタック可能かチェック
        for (int i = 0; i < items.Count; i++)
        {
            Item slotItem = items[i];
            if (slotItem != null && slotItem.itemName == newItem.itemName && slotItem.amount < slotItem.maxStack)
            {
                slotItem.amount++;
                Debug.Log("既存アイテム " + slotItem.itemName + " のスタック増加: " + slotItem.amount);
                FindObjectOfType<InventoryUI>().UpdateUI();
                return true;
            }
        }

        // スタックできるものがなければ、空スロット（null）の場所に新規追加
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == null)
            {
                Item newItemCopy = new Item
                {
                    itemName = newItem.itemName,
                    icon = newItem.icon,
                    maxStack = newItem.maxStack,
                    amount = 1, // 新規追加なので 1 個
                    itemPrefab = newItem.itemPrefab
                };

                items[i] = newItemCopy;
                Debug.Log("新規アイテム追加: " + newItem.itemName + " をスロット " + i + " に追加");
                FindObjectOfType<InventoryUI>().UpdateUI();
                return true;
            }
        }

        Debug.Log("インベントリ満杯！");
        return false;
    }



    public void RemoveItem(Item item)
    {
        // 固定スロット内からアイテム名で対象のスロットを検索
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] != null && items[i].itemName == item.itemName)
            {
                if (items[i].amount > 1)
                {
                    items[i].amount--;
                }
                else
                {
                    // 削除するのではなく、スロットを null にして空にする
                    items[i] = null;
                }
                FindObjectOfType<InventoryUI>().UpdateUI();
                return;
            }
        }
        Debug.LogWarning("RemoveItem: 指定されたアイテムが見つかりません");
    }

}
