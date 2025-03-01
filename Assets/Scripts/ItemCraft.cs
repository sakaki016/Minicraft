
//using System;
//using UnityEngine;

//[Serializable]
//public class Item : MonoBehaviour
//{

//    public enum ItemType
//    {
//        None,
//        Axe,
//        PickeAxe,
//        Shovel,
//        Sword,

//        Rock,
//        Wood,

//    }

//    public ItemType itemType;
//    public int amount = 1;
//    private ItemHolder itemHolder;


//    public void SetItemHolder(ItemHolder itemHolder)
//    {
//        this.itemHolder = itemHolder;
//    }

//    public void RemoveFromItemHolder()
//    {
//        if ((itemHolder!= null))
//        {
//            itemHolder.RemoveItem(this);
//        }
//    }

//    public void RemoveToAnotherItemHolder(ItemHolder newItemHolder)
//    {
//        RemoveFromItemHolder();
//        newItemHolder.AddItem(this);
//    }

//    public Sprite GetSprite()
//    {
//        return GetSprite(itemType);
//    }

//    public static Sprite GetSprite(ItemType itemType)
//    {
//        switch (itemType)
//        {
//            default:
//            case ItemType.Sword: return ItemAssets.Instance.s_Sword;
//        }

//    }

//    public Color GetColor()
//    {
//        return GetColor(itemType);
//    }

//    public static Color GetColor(ItemType itemType)
//    {
//        switch (itemType)
//        {
//            default:
//            case ItemType.Sword: return new Color(1, 1, 1);
//        }
//    }

//    public bool IsStackable()
//    {
//        return IsStackable(itemType);
//    }
//}
