using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    public int hp;

    private void Update()
    {
        if (0 >= hp)
        {
            Destroy(gameObject);
        }
    }
}
