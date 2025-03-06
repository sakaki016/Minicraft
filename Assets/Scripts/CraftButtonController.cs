
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class CraftButtonController : MonoBehaviour
{
    [SerializeField] Button rockButton;
    [SerializeField] Button woodButton;
    [SerializeField] Button back;
    [SerializeField] GameObject stick;
    [SerializeField] GameObject wPickAx;
    [SerializeField] GameObject wSword;
    [SerializeField] GameObject rPickAx;
    [SerializeField] GameObject rSword;

    List<RecipeScriptableObject> recipeScriptableObjectList;

    private Button _selectedButton;


    public void Start()
    {
        _selectedButton = GetComponent<Button>();
        Init();
    }

    /// <summary>
    /// 選択画面を初期化
    /// </summary>
    public void Init()
    {
        back.gameObject.SetActive(false);
        stick.gameObject.SetActive(false);
        wPickAx.gameObject.SetActive(false);
        wSword.gameObject.SetActive(false);
        rPickAx.gameObject.SetActive(false);
        rSword.gameObject.SetActive(false);
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
    /// ボタンクリック
    /// </summary>
    public void OnClick()
    {
        HideMaterial();
        back.gameObject.SetActive(true);

        switch (_selectedButton.name)
        {
            //素材選択
            case "Rock":
                rPickAx.gameObject.SetActive(true);
                rSword.gameObject.SetActive(true);
                break;
            case "Wood":
                stick.gameObject.SetActive(true);
                wPickAx.gameObject.SetActive(true);
                wSword.gameObject.SetActive(true);
                break;

                //木を使ったアイテム
            case "Stick":
                TestCraftScript.Instance.CreateStick();
                break;
            case "WoodAx":
                TestCraftScript.Instance.CreateAx("Wood");
                break;
            case "WoodPickeAx":
                TestCraftScript.Instance.CreatePickeAx("Wood");
                break;
            case "WoodSword":
                TestCraftScript.Instance.CreateSword("Wood");
                break;

                //石を使ったアイテム
            case "RockAx":
                TestCraftScript.Instance.CreateAx("Rock");
                break;
            case "RockPickeAx":
                TestCraftScript.Instance.CreatePickeAx("Rock");
                break;
            case "RockSword":
                TestCraftScript.Instance.CreateSword("Rock");
                break;
        }

    }

}
