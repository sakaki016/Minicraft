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
            transform.rotation = Quaternion.Euler(90f, 0f, 10f);
            Destroy(gameObject);
        }

    }
}
