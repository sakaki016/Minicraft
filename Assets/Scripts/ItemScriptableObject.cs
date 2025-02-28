using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
public class ItemScriptableObject : ScriptableObject
{
    public string itemName; // Name of the item
    public Sprite itemSprite; // Sprite for the item
    public ItemType itemType; // Enum for item type (if used)
}

public enum ItemType
{
    Grass,
    Dirt,
    Rock,
    Brick,
    WoodAxe,
    WoodPickeAxe,
    WoodShovel,
    WoodSword,
    RockAxe,
    RockPickeAxe,
    RockShovel,
    RockSword
}