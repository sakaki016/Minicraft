
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] int hp;

    void DestroyBlock()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
