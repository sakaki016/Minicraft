using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> EnemyList = new List<Enemy>();
    [SerializeField] int popNum = 5; //敵ポップの図

    public void Init()
    {
        // 敵を生成
        for (int i = 0; i < popNum; i++)
        {
            CreateEnemy(new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0));
        }
    }

    public void CreateEnemy(Vector3 pos)
    {
        // Cubeを然るべき場所に生成
        var enemy = GameObject.CreatePrimitive(PrimitiveType.Cube).AddComponent<Enemy>();
        enemy.transform.SetParent(transform);
        enemy.transform.position = pos;

        // 生成後リストに追加
        EnemyList.Add(enemy);
    }
}
