using UnityEngine;
using UnityEngine.UI;

public class CraftSlot : MonoBehaviour
{
    public static CraftSlot Instance { get; private set; }
    public Image itemImage; // アイテムの画像

    void Awake()
    {
        Instance = this;

        // 子オブジェクトからコンポーネントを取得
        itemImage = transform.Find("ItemImage")?.GetComponent<Image>();

        // 初期状態では非表示にする
        if (itemImage != null) itemImage.gameObject.SetActive(false);
    }

    // アイテムをセットする関数
    public void SetItem(Sprite icon)
    {
        if (itemImage != null)
        {
            itemImage.sprite = icon;
            itemImage.gameObject.SetActive(icon != null);
        }

    }

    // スロットを空にする関数
    public void ClearSlot()
    {
        if (itemImage != null)
        {
            itemImage.sprite = null;
            itemImage.gameObject.SetActive(false);
        }
    }
}