using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite icon;
    public int maxStack;
    public GameObject itemPrefab; // ゲーム内で配置する場合のプレハブ


    /*-------------------------↓中西作業↓-------------------------*/
    public ItemScriptableObject itemData; 
    public int amount;

    public Item(ItemScriptableObject data, int amount)
    {
        this.itemData = data;
        this.amount = amount;
    }

    /*-------------------------↑中西作業↑-------------------------*/

}