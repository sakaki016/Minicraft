using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite icon;
    public int maxStack;
    public GameObject itemPrefab; // ゲーム内で配置する場合のプレハブ


    /*-------------------------↓中西作業↓-------------------------*/

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
        return true;// IsStackable(itemType);
    }


    public static bool IsStackable(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Coin:
            case ItemType.HealthPotion:
            case ItemType.ManaPotion:
                return true;
            case ItemType.Sword:
            case ItemType.SwordNone:
            case ItemType.Medkit:
            case ItemType.Sword_1:
            case ItemType.Sword_2:
            case ItemType.HelmetNone:
            case ItemType.Helmet:
            case ItemType.ArmorNone:
            case ItemType.Armor_1:
            case ItemType.Armor_2:
                return false;

            case ItemType.Wood:
            case ItemType.Planks:
            case ItemType.Stick:
            case ItemType.Diamond:
                return true;
            case ItemType.Sword_Diamond:
            case ItemType.Sword_Wood:
                return false;
        }
    }

    public int GetCost()
    {
        return 0;// GetCost(itemType);
    }

    public static int GetCost(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.ArmorNone: return 0;
            case ItemType.Armor_1: return 30;
            case ItemType.Armor_2: return 100;
            case ItemType.HelmetNone: return 0;
            case ItemType.Helmet: return 90;
            case ItemType.HealthPotion: return 30;
            case ItemType.Sword_1: return 0;
            case ItemType.Sword_2: return 150;
        }
    }

    public override string ToString()
    {
        return itemScriptableObject.itemName;
    }

    public CharacterEquipment.EquipSlot GetEquipSlot()
    {
        return itemScriptableObject.equipSlot;
        /*
        switch (itemType) {
        default:
            return CharacterEquipment.EquipSlot.None;
        case ItemType.ArmorNone:
        case ItemType.Armor_1:
        case ItemType.Armor_2:
            return CharacterEquipment.EquipSlot.Armor;
        case ItemType.HelmetNone:
        case ItemType.Helmet:
            return CharacterEquipment.EquipSlot.Helmet;
        case ItemType.SwordNone:
        case ItemType.Sword:
        case ItemType.Sword_1:
        case ItemType.Sword_2:
        case ItemType.Sword_Wood:
        case ItemType.Sword_Diamond:
            return CharacterEquipment.EquipSlot.Weapon;
        }
        */
    }


    /*-------------------------↑中西作業↑-------------------------*/

}