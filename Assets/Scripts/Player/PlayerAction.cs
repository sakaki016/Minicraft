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
    List<int> myItemList = new List<int>();
    [SerializeField] InventoryManager inventoryManager; // インベントリを参照
    [SerializeField] InventoryUI inventoryUI; // インベントリを参照
    Block block;
    Enemy enemy;
    int blockHp;
    int count = 0;

    Vector2 displayCenter;
    // ブロックを設置する位置を一応リアルタイムで格納
    private Vector3 pos;

    private void Start()
    {
        // ↓ 画面中央の平面座標を取得する
        displayCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        inventoryManager = FindObjectOfType<InventoryManager>(); // シーン内のInventoryManagerを取得
    }

        void Update()
    {
        //ターゲットの座標を取得
        Ray ray = Camera.main.ScreenPointToRay(displayCenter);
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
                        // **ブロックのアイテムをインベントリに追加**
                        Item droppedItem = block.GetItem();
                        if (droppedItem != null)
                        {
                            bool added = inventoryManager.AddItem(droppedItem);
                            if (added)
                            {
                                Debug.Log("アイテム追加: " + block.name);
                                inventoryUI.UpdateUI(); // UI 更新を追加

                            }
                            else
                            {
                                Debug.Log("インベントリが満杯です！");
                            }
                        }

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

        if (Physics.Raycast(ray, out hit, 7.0f))
        {
            // ↓ 生成位置の変数の値を「ブロックの向き + ブロックの位置」
            pos = hit.normal + hit.collider.transform.position;
            if (Input.GetMouseButtonDown(1))
            {
                //blocks[1]→myItemListに変更
                Instantiate(blocks[1], pos, Quaternion.identity);
            }
        }

    }

}
