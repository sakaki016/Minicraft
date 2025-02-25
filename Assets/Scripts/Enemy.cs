using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

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
