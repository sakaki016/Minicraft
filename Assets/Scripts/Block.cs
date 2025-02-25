
using UnityEngine;

public class Block : MonoBehaviour
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
