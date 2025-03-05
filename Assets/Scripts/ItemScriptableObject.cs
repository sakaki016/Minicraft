using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
public class ItemScriptableObject : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;

}

public enum ItemType //item‚ÌŽí—Þ‚¸‚¢‚¶’Ç‰Á
{
    None,
    Wood,
    Rock,
    Stick,
    PickeAx,
    Ax_Wood,
    PickeAx_Wood,
    Shovel_Wood,
    Sword_Wood,
    Ax_Rock,
    PickeAx_Rock,
    Shovel_Rock,
    Sword_Rock,
    Sword,
}