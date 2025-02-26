
using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int hp;

    public void DestroyBlock()
    {
        Destroy(gameObject);
    }
}
