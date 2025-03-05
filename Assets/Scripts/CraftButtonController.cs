
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.UI;

public class CraftButtonController : MonoBehaviour
{
    [SerializeField] Button rockButton;
    [SerializeField] Button woodButton;
    [SerializeField] Button back;
    [SerializeField] GameObject stick;
    [SerializeField] GameObject pickAx;
    [SerializeField] GameObject sword;

    List<RecipeScriptableObject> recipeScriptableObjectList;

    private Button _craftItem;
    string material;

  
    public void Start()
    {
        _craftItem = GetComponent<Button>();
        Init();
    }

    /// <summary>
    /// 選択画面を初期化
    /// </summary>
    public void Init()
    {
        back.gameObject.SetActive(false);
        stick.gameObject.SetActive(false);
        pickAx.gameObject.SetActive(false);
        sword.gameObject.SetActive(false);
        rockButton.gameObject.SetActive(true);
        woodButton.gameObject.SetActive(true);
    }

    /// <summary>
    /// 一番上の階層、素材選択ボタンを隠す
    /// </summary>
    public void HideMaterial()
    {
        rockButton.gameObject.SetActive(false);
        woodButton.gameObject.SetActive(false);
    }

    /// <summary>
    /// 石を選択
    /// </summary>
    public void OnClickRock()
    {
        HideMaterial();
        material = "Rock";
        back.gameObject.SetActive(true);
        pickAx.gameObject.SetActive(true);
        sword.gameObject.SetActive(true);
    }

    /// <summary>
    /// 木を選択
    /// </summary>
    public void OnClickWood()
    {
        HideMaterial();
        material = "Wood";
        back.gameObject.SetActive(true);
        stick.gameObject.SetActive(true);
        pickAx.gameObject.SetActive(true);
        sword.gameObject.SetActive(true);
    }

    /// <summary>
    /// 加工するアイテムの分岐
    /// </summary>
    // TODO 余裕があればもっと簡潔にする
    public void SelectItemToCraft()
    {
        //ボタンの名前から派生
        switch (_craftItem.name)
        {
            case "Stick":
                TestCraftScript.Instance.CreateStick();
                break;
            case "PickeAx":
                //TestCraftScript.Instance.CreateAx(material);
                break;
            case "Sword":
                TestCraftScript.Instance.CreateSword(material);
                break;
        }
    }
}
