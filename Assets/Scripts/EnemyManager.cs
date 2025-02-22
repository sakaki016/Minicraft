using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> EnemyList = new List<Enemy>();
    [SerializeField] int popNum = 5; //�G�|�b�v�̐}

    public void Init()
    {
        // �G�𐶐�
        for (int i = 0; i < popNum; i++)
        {
            CreateEnemy(new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0));
        }
    }

    public void CreateEnemy(Vector3 pos)
    {
        // Cube��R��ׂ��ꏊ�ɐ���
        var enemy = GameObject.CreatePrimitive(PrimitiveType.Cube).AddComponent<Enemy>();
        enemy.transform.SetParent(transform);
        enemy.transform.position = pos;

        // �����ナ�X�g�ɒǉ�
        EnemyList.Add(enemy);
    }
}
