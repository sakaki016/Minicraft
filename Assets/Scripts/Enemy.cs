using System.Threading.Tasks;
using System.Threading;
using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] int hp;

    private async ValueTask DelayAsync(CancellationToken token)
    {
        transform.rotation = Quaternion.Euler(90f, 0f, 10f);
        // 1•bŠÔ‘Ò‚Â
        await Task.Delay(TimeSpan.FromSeconds(1.0), token);
    }


    private void Update()
    {
        if (0 >= hp)
        {
            Dead();
        }
    }

    void Dead()
    {
        _ = DelayAsync(destroyCancellationToken);
        Destroy(gameObject);
    }
}
