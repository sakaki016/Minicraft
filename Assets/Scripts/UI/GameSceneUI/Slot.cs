using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    public Image itemImage; // アイテムの画像
    public TextMeshProUGUI itemCountText; // アイテムの数を表示するテキスト

    void Awake()
    {
        // 子オブジェクトからコンポーネントを取得
        itemImage = transform.Find("ItemImage")?.GetComponent<Image>();
        itemCountText = transform.Find("Number")?.GetComponent<TextMeshProUGUI>();

        // 初期状態では非表示にする
        if (itemImage != null) itemImage.gameObject.SetActive(false);
        if (itemCountText != null) itemCountText.text = "";
    }

    // アイテムをセットする関数
    public void SetItem(Sprite icon, int count)
    {
        if (itemImage != null)
        {
            itemImage.sprite = icon;
            itemImage.gameObject.SetActive(icon != null);
        }

        if (itemCountText != null)
        {
            itemCountText.text = (count > 1) ? count.ToString() : "";
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

        if (itemCountText != null)
        {
            itemCountText.text = "";
        }
    }
}