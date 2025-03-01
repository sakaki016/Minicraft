using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
public class ItemScriptableObject : ScriptableObject
{
    //public Item.ItemType itemType;
    public string itemName;
    public Sprite itemSprite;

    //public CharacterEquipment.EquipSlot equipSlot;Å@//Ç¬Ç©Ç§ÅH
}

public enum ItemType //itemÇÃéÌóﬁÇ∏Ç¢Ç∂í«â¡
{
    Wood,
    Rock,
    Sword_Wood,
    Sword_Rock
}