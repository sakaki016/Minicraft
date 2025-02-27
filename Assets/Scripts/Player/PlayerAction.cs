using System.Collections;
using System.Collections.Generic;
using Unity.Android.Gradle;
using UnityEngine;
using System;
using Unity.VisualScripting;
using static UnityEditor.Progress;
using UnityEngine.UIElements;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] GameObject[] blocks;
    [SerializeField] GameObject[] enemys;
    Block block;
    Enemy enemy;
    int blockHp;
    int count = 0;

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
                enemy = hit.collider.gameObject.GetComponent<Enemy>();
                if (Input.GetMouseButtonDown(0))
                {
                    enemy.Hp -= 2;
                    Debug.Log("eneHp=" + enemy.Hp);
                    if (enemy.Hp <= 0)
                    {
                        enemy.DestroyEnemy();
                    }
                }

            }
            else if (hit.collider.CompareTag("Block"))
            {

                
                if (count == 0)
                {
                    block = hit.collider.gameObject.GetComponent<Block>();
                    blockHp = block.Hp;
                    count++;
                }
                if (Input.GetMouseButton(0))
                {

                    blockHp--;
                    if (blockHp <= 0)
                    {
                        block.DestroyBlock();
                        count = 0;
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
    //public int Search(string name)
    //{
    //    var list = new List<string>();
    //    list.AddRange(blocks);
    //    //int num = list.IndexOf(name);
    //    int i;
    //    for (i = 0; i >= blocks.Length; i++)
    //    {
    //        if (list.Contains(name))
    //        {
    //            break;
    //        }
    //    }
    //    //Debug.Log(num);
    //    //return num;
    //    block = blocks[i].GetComponent<Block>();
    //    return block.Hp;
    //}
}
