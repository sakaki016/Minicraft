using System.Collections;
using System.Collections.Generic;
using Unity.Android.Gradle;
using UnityEngine;

public class TargetPositionGet : MonoBehaviour
{
    //const int BLOCK_HP = 500;

    //int bloHp = BLOCK_HP;
    [SerializeField] GameObject blocks;
    Block bloHp;
    int blockHp;
    int eneHp = 20;

    private void Start()
    {//getter block.hp
        bloHp = blocks.GetComponent<Block>();
        blockHp = bloHp.hp;
    }

    void Update()
    {
        //ターゲットの座標を取得
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        //距離が5以内のオブジェクトが対象
        if (Physics.Raycast(ray, out hit, 5.0f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    eneHp -= 2;
                    Debug.Log("eneHp=" + eneHp);
                }

            }
            else if (hit.collider.CompareTag("Block"))
            {
                if (Input.GetMouseButton(0))
                {
                    blockHp--;

                    //bloHp--;
                    Debug.Log("bloHp=" + blockHp);
                }
                else
                {
                    blockHp = bloHp.hp;
                }
            }
        }
        else if (Physics.Raycast(ray, out hit, 5.1f))
        {
            //bloHp = BLOCK_HP;
        }

    }
}
