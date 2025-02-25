
using UnityEngine;

public class Block : MonoBehaviour
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
