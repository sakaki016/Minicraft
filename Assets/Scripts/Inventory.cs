using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : IItemHolder
{
    public event EventHandler OnItemListChanged;

    private List<Item> _itemList;
    private Action<Item> _useItemAction;
    private InventorySlot[] _inventorySlotArray;

    public Inventory(Action<Item> useItemAction)
    {
        this._useItemAction = useItemAction;
        _itemList = new List<Item>();


        /****************テスト用 **************/
        AddItem(new Item { itemType = Item.ItemType.Stick, amount = 10 });
        AddItem(new Item { itemType = Item.ItemType.Rock, amount = 10 });
        AddItem(new Item { itemType = Item.ItemType.Sword_Wood });
        /****************テスト用 **************/

    }

    /// <summary>
    /// インベントリに空きがあることを確認
    /// </summary>
    /// <returns></returns>
    public InventorySlot GetEmptyInventorySlot()
    {
        foreach (InventorySlot inventorySlot in _inventorySlotArray)
        {
            if (inventorySlot.IsEmpty())
            {
                return inventorySlot;
            }
        }
        Debug.LogError("インベントリに空きがない");
        return null;
    }

    public InventorySlot GetInventorySlotWithItem(Item item)
    {
        foreach (InventorySlot inventorySlot in _inventorySlotArray)
        {
            if (inventorySlot.GetItem() == item)
            {
                return inventorySlot;
            }
        }
        Debug.LogError("アイテム： " + item + "がインベントリに無い");
        return null;
    }

    public void AddItem(Item item)
    {
        _itemList.Add(item);
        item.SetItemHolder(this);
        GetEmptyInventorySlot().SetItem(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// アイテムを追加、既存アイテムであれば数を増やす
    /// </summary>
    /// <param name="item">選択したアイテム</param>
    public void AddItemMergeAmount(Item item)
    {
        if (item.IsStackable())
        {
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in _itemList)
            {
                if (inventoryItem.itemScriptableObject == item.itemScriptableObject)
                {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory)
            {
                _itemList.Add(item);
                item.SetItemHolder(this);
                GetEmptyInventorySlot().SetItem(item);
            }
        }
        else
        {
            _itemList.Add(item);
            item.SetItemHolder(this);
            GetEmptyInventorySlot().SetItem(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(Item item)
    {
        GetInventorySlotWithItem(item).RemoveItem();
        _itemList.Remove(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    //↓テスト用
    /*public void RemoveItemAmount(Item.ItemType itemType, int amount) {
        RemoveItemRemoveAmount(new Item { itemType = itemType, amount = amount });
    }*/

    public void RemoveItemRemoveAmount(Item item)
    {
        // アイテムを削除、複数ある場合は数を減らす
        if (item.IsStackable())
        {
            Item itemInInventory = null;
            foreach (Item inventoryItem in _itemList)
            {
                if (inventoryItem.itemScriptableObject == item.itemScriptableObject)
                {
                    inventoryItem.amount -= item.amount;
                    itemInInventory = inventoryItem;
                }
            }
            if (itemInInventory != null && itemInInventory.amount <= 0)
            {
                GetInventorySlotWithItem(itemInInventory).RemoveItem();
                _itemList.Remove(itemInInventory);
            }
        }
        else
        {
            GetInventorySlotWithItem(item).RemoveItem();
            _itemList.Remove(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void AddItem(Item item, InventorySlot inventorySlot)
    {
        // 特定のスロットにアイテムを追加
        _itemList.Add(item);
        item.SetItemHolder(this);
        inventorySlot.SetItem(item);

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void UseItem(Item item)
    {
        _useItemAction(item);
    }

    public List<Item> GetItemList()
    {
        return _itemList;
    }

    public InventorySlot[] GetInventorySlotArray()
    {
        return _inventorySlotArray;
    }

    public bool CanAddItem()
    {
        return GetEmptyInventorySlot() != null;
    }



    public class InventorySlot
    {

        private int index;
        private Item item;

        public InventorySlot(int index)
        {
            this.index = index;
        }

        public Item GetItem()
        {
            return item;
        }

        public void SetItem(Item item)
        {
            this.item = item;
        }

        public void RemoveItem()
        {
            item = null;
        }

        public bool IsEmpty()
        {
            return item == null;
        }

    }

}
