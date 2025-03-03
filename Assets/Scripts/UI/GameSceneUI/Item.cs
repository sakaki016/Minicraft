using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite icon;
    public int maxStack;
    public GameObject itemPrefab; // ゲーム内で配置する場合のプレハブ


    /*----------------------------------------------------↓中西作業↓----------------------------------------------------*/

    public ItemScriptableObject itemScriptableObject;
    //public ItemType itemType;
    public int amount = 1;
    private IItemHolder itemHolder;

    public enum ItemType
    {
        None,
        Sword,
        //HealthPotion,
        Wood,
        Rock,
        Stick,
        Sword_Wood,
        Sword_Rock,
    }

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
            case ItemType.Stick: return ItemAssets.Instance.s_Stick;
            case ItemType.Rock: return ItemAssets.Instance.s_Rock;
            case ItemType.Wood: return ItemAssets.Instance.s_Wood;
        }
    }


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
            case ItemType.Stick:
            case ItemType.Sword_Wood:
            case ItemType.Sword_Rock:
                return false;
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