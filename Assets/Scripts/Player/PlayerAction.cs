using System.Collections;
using System.Collections.Generic;
using Unity.Android.Gradle;
using UnityEngine;
using System;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] GameObject[] blocks;
    [SerializeField] GameObject enemys;
    [SerializeField] SearchBlock searchBlock;
    Block block;
    int blockHp;
    Enemy enemy;
    int count = 0;

    private void Start()
    {
        //block = blocks[0].GetComponent<Block>();
        //blockHp = block.hp;
        //block = blocks.GetComponent<Block>();
        enemy = enemys.GetComponent<Enemy>();
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
                    enemy.hp -= 2;
                    Debug.Log("eneHp=" + enemy.hp);
                }

            }
            else if (hit.collider.CompareTag("Block"))
            {
                //ブロック名→リスト番号→ブロックのhp取得
                string name = hit.collider.gameObject.name;
                Debug.Log(name);
                block.hp = searchBlock.Search(name);
                //int num = searchBlock.Search(name);
                //block = blocks[num].GetComponent<Block>();
                if (count == 0)
                {
                    blockHp = block.hp;
                    count++;
                }
                if (Input.GetMouseButton(0))
                {

                    blockHp--;
                    if (blockHp <= 0)
                    {
                        block.DestroyBlock();
                    }

                    Debug.Log("bloHp=" + blockHp);
                }
                else
                {
                    count = 0;
                }
            }
        }
        else if (Physics.Raycast(ray, out hit, 5.1f))
        {
            count = 0;
        }

    }
}
