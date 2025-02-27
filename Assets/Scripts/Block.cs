
using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] int hp;

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
