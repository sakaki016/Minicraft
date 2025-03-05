
using UnityEngine;
using UnityEngine.UI;

public class CraftButtonController : MonoBehaviour
{
    [SerializeField] Button rockButton;
    [SerializeField] Button woodButton;
    [SerializeField] Button back;
    [SerializeField] GameObject stick;
    [SerializeField] GameObject pickAxe;
    [SerializeField] GameObject sword;

    private Button _craftItem;

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
        pickAxe.gameObject.SetActive(false);
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
        back.gameObject.SetActive(true);
        pickAxe.gameObject.SetActive(true);
        sword.gameObject.SetActive(true);
    }

    /// <summary>
    /// 木を選択
    /// </summary>
    public void OnClickWood()
    {
        HideMaterial();
        back.gameObject.SetActive(true);
        stick.gameObject.SetActive(true);
        pickAxe.gameObject.SetActive(true);
        sword.gameObject.SetActive(true);
    }

    public void CraftItem()
    {

    }

}
