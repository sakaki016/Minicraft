using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditorInternal.ReorderableList;

public class Player : MonoBehaviour
{
    [SerializeField] int Hp;
    private bool isDamage = false;

    void Update()
    {
        if (Hp <= 0)
        {
            Dead();
        }

        if (isDamage)
        {
            //点滅処理
            FlushController.instance.RedFlush();
        }
        else
        {
            FlushController.instance.NoFlush();
        }

    }


    void Dead()
    {
        Debug.Log("ゲームオーバー");
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            if (isDamage) return;

            StartCoroutine(OnDamage());
        }
    }

    public IEnumerator OnDamage()
    {
        isDamage = true;
        Hp -= 10;
        Debug.Log("現在のHP: " + Hp);

        //ノックバック
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(-transform.forward * 2f, ForceMode.VelocityChange);

        yield return new WaitForSeconds(1.5f);

        // 通常状態に戻す
        isDamage = false;

    }
}
