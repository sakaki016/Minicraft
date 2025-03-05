using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    public Image itemImage; // アイテムの画像
    public TextMeshProUGUI itemCountText; // アイテムの数を表示するテキスト
    private Item storedItem; // スロットに保存されているアイテム

    void Awake()
    {
        // 子オブジェクトからコンポーネントを取得
        itemImage = transform.Find("ItemImage")?.GetComponent<Image>();
        itemCountText = transform.Find("Number")?.GetComponent<TextMeshProUGUI>();

        // 初期状態では非表示にする
        if (itemImage != null) itemImage.gameObject.SetActive(false);
        if (itemCountText != null) itemCountText.text = "";
    }

    // アイテムをスロットに設定する（Sprite と 数量）
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
    // アイテムをセットする関数（Itemクラスを直接扱うように変更）
    public void SetItem(Item item)
    {
        storedItem = item; // storedItem を設定
        if (item != null)
        {
            SetItem(item.icon, item.amount); // 既存の SetItem を使う
        }
        else
        {
            ClearSlot();
        }
    }


    // スロットを空にする関数
    public void ClearSlot()
    {
        storedItem = null;
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

    // スロットのアイテムを取得する関数
    public Item GetItem()
    {
        return storedItem;
    }
}
