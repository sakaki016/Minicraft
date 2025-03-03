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
    //public ItemType itemType;
    public int amount = 1;
    private IItemHolder itemHolder;


    public void SetItemHolder(IItemHolder itemHolder)
    {
        this.itemHolder = itemHolder;
    }

    public IItemHolder GetItemHolder()
    {
        return itemHolder;
    }

    public void RemoveFromItemHolder()
    {
        if (itemHolder != null)
        {
            // Remove from current Item Holder
            itemHolder.RemoveItem(this);
        }
    }

    public void MoveToAnotherItemHolder(IItemHolder newItemHolder)
    {
        RemoveFromItemHolder();
        // Add to new Item Holder
        newItemHolder.AddItem(this);
    }



    public Sprite GetSprite()
    {
        return itemScriptableObject.itemSprite;
    }

    public static Sprite GetSprite(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Rock: return ItemAssets.Instance.s_Rock;

            case ItemType.Wood: return ItemAssets.Instance.s_Wood;
        }
    }

    //public Color GetColor()
    //{
    //    return Color.white;// GetColor(itemType);
    //}

    //public static Color GetColor(ItemType itemType)
    //{
    //    switch (itemType)
    //    {
    //        default:
    //        case ItemType.Sword: return new Color(1, 1, 1);
    //        case ItemType.HealthPotion: return new Color(1, 0, 0);
    //        case ItemType.ManaPotion: return new Color(0, 0, 1);
    //        case ItemType.Coin: return new Color(1, 1, 0);
    //        case ItemType.Medkit: return new Color(1, 0, 1);
    //    }
    //}

    public bool IsStackable()
    {
        return true; // IsStackable(itemType);
    }

    public static bool IsStackable(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Wood:
            case ItemType.Rock:
                return true;
            case ItemType.Sword_Wood:
            case ItemType.Sword_Rock:
                return false;
        }
    }

    public static int GetCost(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Sword_Wood: return 0;
            case ItemType.Sword_Rock: return 150;
        }
    }

    public override string ToString()
    {
        return itemScriptableObject.itemName;
    }


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