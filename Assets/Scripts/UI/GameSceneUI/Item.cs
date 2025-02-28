using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite icon;
    public int maxStack;
    public GameObject itemPrefab; // ゲーム内で配置する場合のプレハブ
}