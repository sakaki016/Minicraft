using UnityEngine;
using UnityEngine.AI;

public class EnemyGenerator : MonoBehaviour
{
    //敵プレハブ
    [SerializeField] GameObject[] enemyPrefabs;
    //敵生成時間間隔
    [SerializeField] float interval;
    //敵ポップMAX数
    [SerializeField] int maxPopNum;
    //フィールドサイズ
    [SerializeField] int fieldSizeX;
    [SerializeField] int fieldSizeZ;
    //敵の格納場所
    [SerializeField] Transform enemyParentTransform;
    //経過時間
    private float time = 0f;

    void Update()
    {
        //時間計測
        time += Time.deltaTime;

        //POP最大数を超えないとき。子オブジェクトの現在POP数をとる
        if (enemyParentTransform.transform.childCount < maxPopNum) 
        {
            
            //経過時間が生成時間になったとき(生成時間より大きくなったとき)
            if (time > interval)
            {
                //敵を生成する
                GameObject enemy = Instantiate(getRandomEnemy());
                enemy.GetComponent<NavMeshAgent>().enabled = true; //navmeshをアクティブ化
                //enemyを指定した場所に格納
                enemy.transform.parent = enemyParentTransform;

                //生成した敵の座標を決定する
                enemy.transform.position = new Vector3(Random.Range(0, fieldSizeX), 5f, Random.Range(0, fieldSizeZ));
                //経過時間を初期化して再度時間計測を始める
                time = 0f;
            }
        }
    }

    public GameObject getRandomEnemy()
    {
        int random = Random.Range(0, 4);
        int index;

        //switch文でもいいが出現％調整のためいったんこの形でおいておく
        if (random <2) 
        {
            index = 0;
        }
        else
        {
            index = 1;
        }

        return enemyPrefabs[index];
    }
}
