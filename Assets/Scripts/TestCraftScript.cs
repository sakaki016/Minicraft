
using System;
using System.Collections.Generic;
using Unity.Android.Gradle;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.UI;

/*
    ÅyÉåÉVÉsÅz  
    0 RockAx
    1 RockPickeAx
    2 RockShovel
    3 RockSword
    4 Stick
    5 WoodAx
    6 WoodPickeAx
    7 WoodShovel
    8 WoodSword

    ÅyÉAÉCÉeÉÄÅz
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

    private Sprite newSprite;
    private Image image;

    void Awake()
    {
        Instance = this;

    }

    void Start()
    {
        if (image != null)
        {
            image = item_10.GetComponent<Image>();
        }
    }

    /// <summary>
    /// â¡çHÉXÉçÉbÉgÇÉNÉäÉA
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
        craftMaterials = null;
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
    /// ñ_Çê∂éY
    /// </summary>
    public void CreateStick()
    {
        Clear();

        List<string> recipes = CheckRecipe(4);
        Debug.Log(string.Join(",", recipes));

        //foreach (string recipe in recipes)
        //{
        //    Debug.Log(recipe);
        //}


        newSprite = itemScriptableObjectList[12].itemSprite;

        item_10.GetComponent<Image>().sprite = newSprite;
        item_11.GetComponent<Image>().sprite = newSprite;

        output.GetComponent<Image>().sprite = itemScriptableObjectList[9].itemSprite;
    }

    /// <summary>
    /// åïÇê∂éY
    /// </summary>
    public void CreateSword(string material)
    {
        Clear();
        newSprite = itemScriptableObjectList[9].itemSprite;

        if (material.Equals("Wood"))
        {
            //ñÿÇÃèÍçá
            item_12.GetComponent<Image>().sprite = itemScriptableObjectList[12].itemSprite;
            output.GetComponent<Image>().sprite = itemScriptableObjectList[11].itemSprite;

            List<string> recipes = CheckRecipe(8);
            Debug.Log(string.Join(",", recipes));

            //foreach (string recipe in recipes)
            //{
            //    Debug.Log(recipe);
            //}

        }
        else if (material.Equals("Rock"))
        {
            //êŒÇÃèÍçá
            item_12.GetComponent<Image>().sprite = itemScriptableObjectList[6].itemSprite;
            output.GetComponent<Image>().sprite = itemScriptableObjectList[10].itemSprite;

            List<string> recipes = CheckRecipe(3);
            Debug.Log(string.Join(",", recipes));

            //foreach (string recipe in recipes)
            //{
            //    Debug.Log(recipe);
            //}
        }

        item_10.GetComponent<Image>().sprite = newSprite;
        item_11.GetComponent<Image>().sprite = newSprite;

    }

    /// <summary>
    /// ÉIÉmÇê∂éY
    /// </summary>
    public void CreateAx(string material)
    {
        Clear();
        newSprite = itemScriptableObjectList[9].itemSprite;
        Debug.Log(material);
        if (material.Equals("Wood"))
        {
            //ñÿÇÃèÍçá
            item_12.GetComponent<Image>().sprite = itemScriptableObjectList[12].itemSprite;
            item_02.GetComponent<Image>().sprite = itemScriptableObjectList[12].itemSprite;
            item_01.GetComponent<Image>().sprite = itemScriptableObjectList[12].itemSprite;
            output.GetComponent<Image>().sprite = itemScriptableObjectList[1].itemSprite;

            List<string> recipes = CheckRecipe(5);
            Debug.Log(string.Join(",", recipes));

            //foreach (string recipe in recipes)
            //{
            //    Debug.Log(recipe);
            //}

        }
        else if (material.Equals("Rock"))
        {
            //êŒÇÃèÍçá
            item_12.GetComponent<Image>().sprite = itemScriptableObjectList[6].itemSprite;
            item_02.GetComponent<Image>().sprite = itemScriptableObjectList[6].itemSprite;
            item_01.GetComponent<Image>().sprite = itemScriptableObjectList[6].itemSprite;
            output.GetComponent<Image>().sprite = itemScriptableObjectList[0].itemSprite;

            List<string> recipes = CheckRecipe(0);
            Debug.Log(string.Join(",", recipes));

            //foreach (string recipe in recipes)
            //{
            //    Debug.Log(recipe);
            //}
        }

        item_10.GetComponent<Image>().sprite = newSprite;
        item_11.GetComponent<Image>().sprite = newSprite;
    }

    /// <summary>
    /// ÉsÉbÉPÉãÇê∂éY
    /// </summary>
    public void CreatePickeAx(string material)
    {
        Clear();
        newSprite = itemScriptableObjectList[9].itemSprite;
        Debug.Log(material);
        if (material.Equals("Wood"))
        {
            //ñÿÇÃèÍçá
            item_02.GetComponent<Image>().sprite = itemScriptableObjectList[12].itemSprite;
            item_12.GetComponent<Image>().sprite = itemScriptableObjectList[12].itemSprite;
            item_22.GetComponent<Image>().sprite = itemScriptableObjectList[12].itemSprite;
            output.GetComponent<Image>().sprite = itemScriptableObjectList[5].itemSprite;

            List<string> recipes = CheckRecipe(6);
            Debug.Log(string.Join(",", recipes));

            //foreach (string recipe in recipes)
            //{
            //    Debug.Log(recipe);
            //}

        }
        else if (material.Equals("Rock"))
        {
            //êŒÇÃèÍçá
            item_02.GetComponent<Image>().sprite = itemScriptableObjectList[6].itemSprite;
            item_12.GetComponent<Image>().sprite = itemScriptableObjectList[6].itemSprite;
            item_22.GetComponent<Image>().sprite = itemScriptableObjectList[6].itemSprite;
            output.GetComponent<Image>().sprite = itemScriptableObjectList[4].itemSprite;

            List<string> recipes = CheckRecipe(1);
            Debug.Log(string.Join(",", recipes));

            //foreach (string recipe in recipes)
            //{
            //    Debug.Log(recipe);
            //}
        }

        item_10.GetComponent<Image>().sprite = newSprite;
        item_11.GetComponent<Image>().sprite = newSprite;
    }
}

