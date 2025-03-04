using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSystem : IItemHolder
{

    public const int GRID_SIZE = 3;

    public event EventHandler OnGridChanged;

    private List<RecipeScriptableObject> recipeScriptableObjectList;

    private Item[,] itemArray;
    private Item outputItem;

    public CraftingSystem(List<RecipeScriptableObject> recipeScriptableObjectList)
    {
        this.recipeScriptableObjectList = recipeScriptableObjectList;

        itemArray = new Item[GRID_SIZE, GRID_SIZE];
       
    }

    public bool IsEmpty(int x, int y)
    {
        return itemArray[x, y] == null;
    }

    public Item GetItem(int x, int y)
    {
        return itemArray[x, y];
    }

    public void SetItem(Item item, int x, int y)
    {
        if (item != null)
        {
            item.RemoveFromItemHolder();
            item.SetItemHolder(this);
        }
        itemArray[x, y] = item;
        CreateOutput();
        OnGridChanged?.Invoke(this, EventArgs.Empty);
    }

    public void IncreaseItemAmount(int x, int y)
    {
        GetItem(x, y).amount++;
        OnGridChanged?.Invoke(this, EventArgs.Empty);
    }

    public void DecreaseItemAmount(int x, int y)
    {
        if (GetItem(x, y) != null)
        {
            GetItem(x, y).amount--;
            if (GetItem(x, y).amount == 0)
            {
                RemoveItem(x, y);
            }
            OnGridChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public void RemoveItem(int x, int y)
    {
        SetItem(null, x, y);
    }

    public bool TryAddItem(Item item, int x, int y)
    {
        if (IsEmpty(x, y))
        {
            SetItem(item, x, y);
            return true;
        }
        else
        {
            if (item.itemScriptableObject == GetItem(x, y).itemScriptableObject)
            {
                IncreaseItemAmount(x, y);
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public void RemoveItem(Item item)
    {
        if (item == outputItem)
        {
            // アウトプットにあるアイテムを削除
            ConsumeRecipeItems();
            CreateOutput();
            OnGridChanged?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            // スロットからアイテムを外したとき
            for (int x = 0; x < GRID_SIZE; x++)
            {
                for (int y = 0; y < GRID_SIZE; y++)
                {
                    if (GetItem(x, y) == item)
                    {
                        // これを削除
                        RemoveItem(x, y);
                    }
                }
            }
        }
    }

    public void AddItem(Item item) { }

    public bool CanAddItem() { return false; }


    private ItemScriptableObject GetRecipeOutput()
    {
        foreach (RecipeScriptableObject recipeScriptableObject in recipeScriptableObjectList)
        {

            bool completeRecipe = true;
            for (int x = 0; x < GRID_SIZE; x++)
            {
                for (int y = 0; y < GRID_SIZE; y++)
                {
                    if (recipeScriptableObject.GetItem(x, y) != null)
                    {
                        // レシピにおいて、アイテムがある
                        if (IsEmpty(x, y) || GetItem(x, y).itemScriptableObject != recipeScriptableObject.GetItem(x, y))
                        {
                            // Empty position or different itemType
                            completeRecipe = false;
                        }
                    }
                }
            }

            if (completeRecipe)
            {
                return recipeScriptableObject.output;
            }
        }
        return null;
    }

    private void CreateOutput()
    {
        ItemScriptableObject recipeOutput = GetRecipeOutput();
        if (recipeOutput == null)
        {
            outputItem = null;
        }
        else
        {
            outputItem = new Item { itemScriptableObject = recipeOutput };
            outputItem.SetItemHolder(this);
        }
    }

    public Item GetOutputItem()
    {
        return outputItem;
    }

    public void ConsumeRecipeItems()
    {
        for (int x = 0; x < GRID_SIZE; x++)
        {
            for (int y = 0; y < GRID_SIZE; y++)
            {
                DecreaseItemAmount(x, y);
            }
        }
    }
}
