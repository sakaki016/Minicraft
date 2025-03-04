using UnityEngine;

public class Enemy : MonoBehaviour
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

    public void DestroyEnemy()
    {
        Destroy(gameObject);

    }
}
