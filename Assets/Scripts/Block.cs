
using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] int number;
    [SerializeField] Item blockItem; // このブロックがドロップするアイテム

    public int Hp
    {
        set
        {
            hp = value;
        }
        get
        {
            return hp;
        }
    }

    public void DestroyBlock()
    {
        Destroy(gameObject);
    }
}
