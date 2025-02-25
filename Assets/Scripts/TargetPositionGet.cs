using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPositionGet : MonoBehaviour
{
    const int HP = 500;
    int hp = HP;

    void Update()
    {
        //ターゲットの座標を取得
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButton(0))
        {
            //距離が5以内のオブジェクトが対象
            if (Physics.Raycast(ray, out hit, 5.0f))
            {
                //if (hit.collider.gameObject.tag == "Enemy")
                if (hit.collider.CompareTag("Enemy"))
                {
                    hp = 900000;
                }
                hp--;
                Debug.Log(hp);
            }
            else if (Physics.Raycast(ray, out hit, 5.1f))
            {
                hp = HP;
            }
        }
        else
        {
            hp = HP;
        }

    }
}
