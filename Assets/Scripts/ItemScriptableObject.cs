using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
public class ItemScriptableObject : ScriptableObject
{
    public string itemName; // アイテム名
    public Sprite itemSprite; // アイテムのSprite
    public ItemType itemType;
}

public enum ItemType
{
    Wood,
    Rock,
}