using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int hp;

    private void Update()
    {
        if (0 >= hp)
        {
            Destroy(gameObject);
        }
    }
}
