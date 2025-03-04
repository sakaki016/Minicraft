using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite icon;
    public int maxStack;
    public int count;
    public GameObject itemPrefab; // ゲーム内で配置する場合のプレハブ


    /*----------------------------------------------------↓中西作業↓----------------------------------------------------*/

    public ItemScriptableObject itemScriptableObject;
    /*********↓テスト用↓**********/
    public ItemType itemType;
    /*********↑テスト用↑**********/
    public int amount = 1;
    private IItemHolder itemHolder;

    public enum ItemType
    {
        None,
        Sword,
        //HealthPotion,
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

    //public void SetItemHolder(IItemHolder itemHolder)
    //{
    //    this.itemHolder = itemHolder;
    //}

    //public IItemHolder GetItemHolder()
    //{
    //    return itemHolder;
    //}

    //public void RemoveFromItemHolder()
    //{
    //    if (itemHolder != null)
    //    {
    //        // ホルダーから削除
    //        itemHolder.RemoveItem(this);
    //    }
    //}

    ///// <summary>
    ///// アイテム移動
    ///// </summary>
    ///// <param name="newItemHolder"></param>
    //public void MoveToAnotherItemHolder(IItemHolder newItemHolder)
    //{
    //    RemoveFromItemHolder();
    //    // Add to new Item Holder
    //    newItemHolder.AddItem(this);
    //}



    //public Sprite GetSprite()
    //{
    //    return itemScriptableObject.itemSprite;
    //}

    //public static Sprite GetSprite(ItemType itemType)
    //{
    //    switch (itemType)
    //    {
    //        default:
    //        case ItemType.Stick: return ItemAssets.Instance.s_Stick;
    //        case ItemType.Rock: return ItemAssets.Instance.s_Rock;
    //        case ItemType.Wood: return ItemAssets.Instance.s_Wood;
    //    }
    //}


    ////スタックできるか
    //public bool IsStackable()
    //{
    //    return true;
    //}

    //public static bool IsStackable(ItemType itemType)
    //{
    //    switch (itemType)
    //    {
    //        default:
    //        case ItemType.Wood:
    //        case ItemType.Rock:
    //        case ItemType.Dirt:
    //        case ItemType.Leaf:
    //            return true; // ↑スタックできる
    //        case ItemType.Stick:
    //        case ItemType.Sword_Wood:
    //        case ItemType.Sword_Rock:
    //        case ItemType.Ax_Wood:
    //        case ItemType.Ax_Rock:
    //        case ItemType.PickeAx_Wood:
    //        case ItemType.PickeAx_Rock:
    //        case ItemType.Shovel_Rock:
    //        case ItemType.Shovel_Wood:
    //            return false; // ↑スタックできない
    //    }
    //}

    //public override string ToString()
    //{
    //    return itemScriptableObject.itemName;
    //}


    //public CharacterEquipment.EquipSlot GetEquipSlot() //つかう？
    //{
    //    return itemScriptableObject.equipSlot;
    /*
    switch (itemType) {
    default:
    case ItemType.SwordNone:
    case ItemType.Sword_Wood:
    case ItemType.Sword_Rock:
        return CharacterEquipment.EquipSlot.Weapon;
    }
    */
    //}

    /*----------------------------------------------------↑中西作業↑----------------------------------------------------*/

}