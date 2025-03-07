
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/*
    【レシピ】  
    0 RockAx
    1 RockPickeAx
    2 RockShovel
    3 RockSword
    4 Stick
    5 WoodAx
    6 WoodPickeAx
    7 WoodShovel
    8 WoodSword

    【アイテム】
    0 RockAx
    1 WoodAx
    2 Dirt
    3 Leaf
    4 RockPickeAx
    5 WoodPickeAx
    6 Rock
    7 RockShovel
    8 WoodShovel
    9 Stick
    10 RockSword
    11 WoodSword
    12 Wood
    13 None
 */

public class TestCraftScript : MonoBehaviour
{
    public static TestCraftScript Instance { get; private set; }

    [SerializeField] List<RecipeScriptableObject> recipeScriptableObjectList;
    [SerializeField] List<ItemScriptableObject> itemScriptableObjectList;

    List<String> craftMaterials = new List<String>();

    [SerializeField] GameObject item_02;
    [SerializeField] GameObject item_12;
    [SerializeField] GameObject item_22;

    [SerializeField] GameObject item_01;
    [SerializeField] GameObject item_11;
    [SerializeField] GameObject item_21;

    [SerializeField] GameObject item_00;
    [SerializeField] GameObject item_10;
    [SerializeField] GameObject item_20;

    [SerializeField] GameObject output;

    [SerializeField] Button craftButton;

    [SerializeField] PlayerAction playerAction;

    private Sprite newSprite;
    private Image image;

    private bool hasCraftItems = false;

    void Awake()
    {
        Instance = this;

    }

    private void Update()
    {
        //if (hasCraftItems) { 
        craftButton.enabled = true;
        //}
        //else
        //{
        //    craftButton.enabled = false;
        //}

    }

    /// <summary>
    /// 加工スロットをクリア
    /// </summary>
    void Clear()
    {

        item_02.GetComponent<Image>().sprite = itemScriptableObjectList[13].itemSprite;
        item_12.GetComponent<Image>().sprite = itemScriptableObjectList[13].itemSprite;
        item_22.GetComponent<Image>().sprite = itemScriptableObjectList[13].itemSprite;

        item_01.GetComponent<Image>().sprite = itemScriptableObjectList[13].itemSprite;
        item_11.GetComponent<Image>().sprite = itemScriptableObjectList[13].itemSprite;
        item_21.GetComponent<Image>().sprite = itemScriptableObjectList[13].itemSprite;

        item_00.GetComponent<Image>().sprite = itemScriptableObjectList[13].itemSprite;
        item_10.GetComponent<Image>().sprite = itemScriptableObjectList[13].itemSprite;
        item_20.GetComponent<Image>().sprite = itemScriptableObjectList[13].itemSprite;

    }

    public List<String> CheckRecipe(int element)
    {
        craftMaterials.Clear();
        if (recipeScriptableObjectList[element].item_02 != null) craftMaterials.Add(recipeScriptableObjectList[element].item_02.name);
        if (recipeScriptableObjectList[element].item_12 != null) craftMaterials.Add(recipeScriptableObjectList[element].item_12.name);
        if (recipeScriptableObjectList[element].item_22 != null) craftMaterials.Add(recipeScriptableObjectList[element].item_22.name);

        if (recipeScriptableObjectList[element].item_01 != null) craftMaterials.Add(recipeScriptableObjectList[element].item_01.name);
        if (recipeScriptableObjectList[element].item_11 != null) craftMaterials.Add(recipeScriptableObjectList[element].item_11.name);
        if (recipeScriptableObjectList[element].item_21 != null) craftMaterials.Add(recipeScriptableObjectList[element].item_21.name);

        if (recipeScriptableObjectList[element].item_00 != null) craftMaterials.Add(recipeScriptableObjectList[element].item_00.name);
        if (recipeScriptableObjectList[element].item_10 != null) craftMaterials.Add(recipeScriptableObjectList[element].item_10.name);
        if (recipeScriptableObjectList[element].item_20 != null) craftMaterials.Add(recipeScriptableObjectList[element].item_20.name);


        return craftMaterials;
    }

    /// <summary>
    /// 棒を生産
    /// </summary>
    public void CreateStick()
    {
        Clear();

        List<string> recipes = CheckRecipe(4);

        //レシピに必要なアイテムとその個数
        foreach (var g in recipes.ToLookup(s => s))
        {
            Debug.Log(g.Key + ": " + g.Count());
        }


        newSprite = itemScriptableObjectList[12].itemSprite;

        item_10.GetComponent<Image>().sprite = newSprite;
        item_11.GetComponent<Image>().sprite = newSprite;

        output.GetComponent<Image>().sprite = itemScriptableObjectList[9].itemSprite;

    }

    /// <summary>
    /// 剣を生産
    /// </summary>
    public void CreateSword(string material)
    {
        Clear();
        newSprite = itemScriptableObjectList[9].itemSprite;

        if (material.Equals("Wood"))
        {
            //木の場合
            item_12.GetComponent<Image>().sprite = itemScriptableObjectList[12].itemSprite;
            item_11.GetComponent<Image>().sprite = itemScriptableObjectList[12].itemSprite;
            output.GetComponent<Image>().sprite = itemScriptableObjectList[11].itemSprite;

            List<string> recipes = CheckRecipe(8);
            Debug.Log(string.Join(",", recipes));

            CheckInventory(recipes);

        }
        else if (material.Equals("Rock"))
        {
            //石の場合
            item_12.GetComponent<Image>().sprite = itemScriptableObjectList[6].itemSprite;
            item_11.GetComponent<Image>().sprite = itemScriptableObjectList[6].itemSprite;
            output.GetComponent<Image>().sprite = itemScriptableObjectList[10].itemSprite;

            List<string> recipes = CheckRecipe(3);
            Debug.Log(string.Join(",", recipes));

            CheckInventory(recipes);
        }

        item_10.GetComponent<Image>().sprite = newSprite;
        

    }

    /// <summary>
    /// オノを生産
    /// </summary>
    public void CreateAx(string material)
    {
        Clear();
        newSprite = itemScriptableObjectList[9].itemSprite;
        Debug.Log(material);
        if (material.Equals("Wood"))
        {
            //木の場合
            item_12.GetComponent<Image>().sprite = itemScriptableObjectList[12].itemSprite;
            item_02.GetComponent<Image>().sprite = itemScriptableObjectList[12].itemSprite;
            item_01.GetComponent<Image>().sprite = itemScriptableObjectList[12].itemSprite;
            output.GetComponent<Image>().sprite = itemScriptableObjectList[1].itemSprite;

            List<string> recipes = CheckRecipe(5);
            Debug.Log(string.Join(",", recipes));

            CheckInventory(recipes);

        }
        else if (material.Equals("Rock"))
        {
            //石の場合
            item_12.GetComponent<Image>().sprite = itemScriptableObjectList[6].itemSprite;
            item_02.GetComponent<Image>().sprite = itemScriptableObjectList[6].itemSprite;
            item_01.GetComponent<Image>().sprite = itemScriptableObjectList[6].itemSprite;
            output.GetComponent<Image>().sprite = itemScriptableObjectList[0].itemSprite;

            List<string> recipes = CheckRecipe(0);
            Debug.Log(string.Join(",", recipes));

            CheckInventory(recipes);
        }

        item_10.GetComponent<Image>().sprite = newSprite;
        item_11.GetComponent<Image>().sprite = newSprite;
    }

    /// <summary>
    /// ピッケルを生産
    /// </summary>
    public void CreatePickeAx(string material)
    {
        Clear();
        newSprite = itemScriptableObjectList[9].itemSprite;
        Debug.Log(material);
        if (material.Equals("Wood"))
        {
            //木の場合
            item_02.GetComponent<Image>().sprite = itemScriptableObjectList[12].itemSprite;
            item_12.GetComponent<Image>().sprite = itemScriptableObjectList[12].itemSprite;
            item_22.GetComponent<Image>().sprite = itemScriptableObjectList[12].itemSprite;
            output.GetComponent<Image>().sprite = itemScriptableObjectList[5].itemSprite;

            List<string> recipes = CheckRecipe(6);
            Debug.Log(string.Join(",", recipes));

            CheckInventory(recipes);

        }
        else if (material.Equals("Rock"))
        {
            //石の場合
            item_02.GetComponent<Image>().sprite = itemScriptableObjectList[6].itemSprite;
            item_12.GetComponent<Image>().sprite = itemScriptableObjectList[6].itemSprite;
            item_22.GetComponent<Image>().sprite = itemScriptableObjectList[6].itemSprite;
            output.GetComponent<Image>().sprite = itemScriptableObjectList[4].itemSprite;

            List<string> recipes = CheckRecipe(1);
            Debug.Log(string.Join(",", recipes));

            CheckInventory(recipes);
        }

        item_10.GetComponent<Image>().sprite = newSprite;
        item_11.GetComponent<Image>().sprite = newSprite;

    }

    public void CheckInventory(List<string> requiredItems)
    {
        //インベントリ内のアイテム＋個数を取得
        List<Item> inventoryItems = InventoryManager.Instance.items;

        //レシピに必要なアイテムとその個数
        foreach (var g in requiredItems.ToLookup(s => s))
        {
            string itemName = g.Key;
            Debug.Log(g.Key + ": " + g.Count());
        }
    }


    public bool ResumeCraft()
    {
        //インベントリ内のアイテム＋個数を取得
       List<Item> inventoryItems = InventoryManager.Instance.items;

        foreach (Item item in inventoryItems)
        {
            Debug.Log("インベントリ内のアイテム..."+ item.itemName + ": " + item.amount + "個");
        }
        return true;

    }
}

