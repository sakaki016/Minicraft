using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite icon;
    public int maxStack;
    public int count;
    public GameObject itemPrefab; // ゲーム内で配置する場合のプレハブ
    public int amount = 1;
    public ItemScriptableObject itemScriptableObject;

    /*----------------------------------------------------↓中西作業↓----------------------------------------------------*/



    public enum ItemType
    {
        None,
        Sword,
        PickeAx,
        Wood,
        Rock,
        Dirt,
        Leaf,
        Stick,

        Sword_Wood,
        Sword_Rock,
        Ax_Wood,
        Ax_Rock,
        PickeAx_Wood,
        PickeAx_Rock,
        Shovel_Rock,
        Shovel_Wood,
    }

    

    /*----------------------------------------------------↑中西作業↑----------------------------------------------------*/

}