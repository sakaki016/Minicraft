using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CraftingSystem : MonoBehaviour
{

    [SerializeField] private Transform pfUI_Item;

    private Transform[,] slotTransformArray;
    private Transform outputSlotTransform;
    private Transform itemContainer;
    private CraftingSystem craftingSystem;

    private void Awake()
    {
        Transform slotContainer = transform.Find("SlotContainer");
        itemContainer = transform.Find("ItemContainer");

        slotTransformArray = new Transform[CraftingSystem.GRID_SIZE, CraftingSystem.GRID_SIZE];

        for (int x = 0; x < CraftingSystem.GRID_SIZE; x++)
        {
            for (int y = 0; y < CraftingSystem.GRID_SIZE; y++)　// 3x3を取得
            {
                slotTransformArray[x, y] = slotContainer.Find("slot_" + x + "_" + y);
                UI_CraftingSlot craftingItemSlot = slotTransformArray[x, y].GetComponent<UI_CraftingSlot>();
                craftingItemSlot.SetXY(x, y);
                craftingItemSlot.OnItemDropped += UI_CraftingSystem_OnItemDropped;
            }
        }

        outputSlotTransform = transform.Find("OutputSlot");


        //CreateItem(1, 2, new Item { itemType = Item.ItemType.Wood }); // *****本番は消す****
        //CreateItemOutput(new Item { itemType = Item.ItemType.Sword_Wood }); // *****本番は消す****
    }

    public void SetCraftingSystem(CraftingSystem craftingSystem)
    {
        this.craftingSystem = craftingSystem;
        craftingSystem.OnGridChanged += CraftingSystem_OnGridChanged;

        UpdateVisual();
    }

    private void CraftingSystem_OnGridChanged(object sender, System.EventArgs e) //グリッドに変更が入った場合は更新
    {
        UpdateVisual();
    }

    private void UI_CraftingSystem_OnItemDropped(object sender, UI_CraftingSlot.OnItemDroppedEventArgs e)
    {
        craftingSystem.TryAddItem(e.item, e.x, e.y);
    }

    private void UpdateVisual() // 更新
    {
        // 元から入ってたアイテムを削除
        foreach (Transform child in itemContainer)
        {
            Destroy(child.gameObject);
        }

        // あれば表示
        for (int x = 0; x < CraftingSystem.GRID_SIZE; x++)
        {
            for (int y = 0; y < CraftingSystem.GRID_SIZE; y++)
            {
                if (!craftingSystem.IsEmpty(x, y))
                {
                    CreateItem(x, y, craftingSystem.GetItem(x, y));
                }
            }
        }

        if (craftingSystem.GetOutputItem() != null)
        {
            CreateItemOutput(craftingSystem.GetOutputItem());
        }
    }

    private void CreateItem(int x, int y, Item item)
    {
        Transform itemTransform = Instantiate(pfUI_Item, itemContainer);
        RectTransform itemRectTransform = itemTransform.GetComponent<RectTransform>();
        itemRectTransform.anchoredPosition = slotTransformArray[x, y].GetComponent<RectTransform>().anchoredPosition;
        itemTransform.GetComponent<UI_Item>().SetItem(item);
    }

    private void CreateItemOutput(Item item)
    {
        Transform itemTransform = Instantiate(pfUI_Item, itemContainer);
        RectTransform itemRectTransform = itemTransform.GetComponent<RectTransform>();
        itemRectTransform.anchoredPosition = outputSlotTransform.GetComponent<RectTransform>().anchoredPosition;
        itemTransform.localScale = Vector3.one * 1.5f;
        itemTransform.GetComponent<UI_Item>().SetItem(item);
    }

}
