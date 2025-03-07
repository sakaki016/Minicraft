using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isDamage = false;
    //ゲームオーバーUI
    public GameObject gameOverUi;
    public GameObject belongingUi;
    public GameObject inventoryUi;
    private bool isDead = false;

    void Update()
    {
        if (PlayerStats.instance.Health <= 0) //HPが0以下になったら
        {
            Dead();
        }

        if (isDamage && isDead == false) //ダメージ中は
        {
            FlushController.instance.RedFlush(); //点滅
        }
        else
        {
            FlushController.instance.NoFlush();
        }
    }


    void Dead()
    {
        isDead = true;
        GetComponent<PlayerMovement>().enabled = false;
        inventoryUi.SetActive(false);
        belongingUi.SetActive(false);
        gameOverUi.SetActive(true);

        if (Input.GetKeyDown(KeyCode.R)) {
            isDead = false;
            GetComponent<PlayerMovement>().enabled = true;
            belongingUi.SetActive(true);
            gameOverUi.SetActive(false);

            PlayerStats.instance.Heal(5);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Enemy" && isDead == false)
        {
            if (isDamage) return;

            StartCoroutine(OnDamage());
        }
    }

    public IEnumerator OnDamage()
    {
        isDamage = true;
        PlayerStats.instance.TakeDamage(1);

        //ノックバック
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(-transform.forward * 2f, ForceMode.VelocityChange);

        yield return new WaitForSeconds(1.5f);

        // 通常状態に戻す
        isDamage = false;
    }
}
