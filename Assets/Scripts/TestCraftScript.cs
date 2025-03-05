
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestCraftScript : MonoBehaviour
{
    public static TestCraftScript Instance { get; private set; }

    [SerializeField] List<RecipeScriptableObject> recipeScriptableObjectList;
    [SerializeField] List<ItemScriptableObject> itemScriptableObjectList;

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
        if (image != null) {
            image = item_10.GetComponent<Image>();
        }
    }

    void Clear()
    {
        
    }


    public void CreateStick()
    {
        newSprite = itemScriptableObjectList[12].itemSprite;

        item_10.GetComponent<Image>().sprite = newSprite;
        item_11.GetComponent<Image>().sprite = newSprite;

        output.GetComponent<Image>().sprite = itemScriptableObjectList[9].itemSprite;
    }

    public void CreateSword(string material)
    {
        newSprite = itemScriptableObjectList[12].itemSprite;
        Debug.Log(material);
        if (material.Equals("Wood"))
        {
            //�؂̏ꍇ
            item_12.GetComponent<Image>().sprite = itemScriptableObjectList[12].itemSprite;
            output.GetComponent<Image>().sprite = itemScriptableObjectList[11].itemSprite;

        } else if (material.Equals("Rock"))
        {
            //�΂̏ꍇ
            item_12.GetComponent<Image>().sprite = itemScriptableObjectList[6].itemSprite;
            output.GetComponent<Image>().sprite = itemScriptableObjectList[10].itemSprite;
        }
        else
        {
            Debug.Log("error!");
        }
            
        item_10.GetComponent<Image>().sprite = newSprite;
        item_11.GetComponent<Image>().sprite = newSprite;
 
    }
}

