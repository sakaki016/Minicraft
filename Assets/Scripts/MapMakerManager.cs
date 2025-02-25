using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// ランダムにマップを生成するクラス
/// </summary>
public class MapMakerManager : MonoBehaviour
{
    // シード値（ノイズ用）
    private float _seedX, _seedZ;

    [SerializeField]
    [Header("------実行中に変えれない------")]
    private float _width = 50; // マップの幅
    [SerializeField]
    private float _depth = 50; // マップの奥行き

    [SerializeField]
    private bool _needToCollider = false; // コライダーをつけるかどうか

    [SerializeField]
    [Header("------実行中に変えられる------")]
    private float _maxHeight = 10; // 最大高さ

    [SerializeField]
    private bool _isPerlinNoiseMap = true; // パーリンノイズを使うか

    [SerializeField]
    private float _relief = 15f; // 起伏の激しさ

    [SerializeField]
    private bool _isSmoothness = false; // 高さを滑らかにするか

    [SerializeField]
    private float _mapSize = 1f; // マップのスケール

    private void Awake()
    {
        // マップのスケール設定
        transform.localScale = new Vector3(_mapSize, _mapSize, _mapSize);

        // シード値の初期化（ノイズで使う）
        _seedX = Random.value * 100f;
        _seedZ = Random.value * 100f;

        // マップの生成
        for (int x = 0; x < _width; x++)
        {
            for (int z = 0; z < _depth; z++)
            {
                // キューブを生成
                GameObject topCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                topCube.transform.localPosition = new Vector3(x, 0, z);
                topCube.transform.SetParent(transform);

                // コライダーが不要なら削除
                if (!_needToCollider)
                {
                    Destroy(topCube.GetComponent<BoxCollider>());
                }

                // 高さを設定
                float topY = SetY(topCube);

                for (float y = topY - 1; y >= -5; y--)
                {
                    GameObject underCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    underCube.transform.localPosition = new Vector3(x, y, z);
                    underCube.transform.SetParent(transform);

                    // コライダーが不要なら削除
                    if (!_needToCollider)
                    {
                        Destroy(underCube.GetComponent<BoxCollider>());
                    }

                    // 高さに応じた色を設定
                    Color color = Color.black;
                    if (y > _maxHeight * 0.6f)
                    {
                        ColorUtility.TryParseHtmlString("#FF0000", out color); // 土っぽい色
                    }
                    else if (y > _maxHeight * 0.3f)
                    {
                        ColorUtility.TryParseHtmlString("#00FF00", out color); // 水っぽい色
                    }
                    else
                    {
                        ColorUtility.TryParseHtmlString("#0000FF", out color); // マグマっぽい色
                    }

                    // キューブに色を適用
                    underCube.GetComponent<MeshRenderer>().material.color = color;
                }
            }
        }
    }

    private void OnValidate()
    {
        // 実行中でなければ処理しない
        if (!Application.isPlaying)
        {
            return;
        }

        // マップのスケールを更新
        transform.localScale = new Vector3(_mapSize, _mapSize, _mapSize);

        // すべての子オブジェクト（キューブ）のY座標を更新
        foreach (Transform child in transform)
        {
            SetY(child.gameObject);
        }
    }

    /// <summary>
    /// キューブのY座標を設定する
    /// </summary>
    /// <param name="cube">対象のキューブ</param>
    /// <returns>設定されたY座標</returns>
    private float SetY(GameObject cube)
    {
        float y = 0;

        if (_isPerlinNoiseMap)
        {
            float xSample = (cube.transform.localPosition.x + _seedX) / _relief;
            float zSample = (cube.transform.localPosition.z + _seedZ) / _relief;
            float noise = Mathf.PerlinNoise(xSample, zSample);
            y = _maxHeight * noise;
        }
        else
        {
            y = Random.Range(0, _maxHeight);
        }

        if (!_isSmoothness)
        {
            y = Mathf.Round(y);
        }

        cube.transform.localPosition = new Vector3(cube.transform.localPosition.x, y, cube.transform.localPosition.z);

        // 高さに応じた色を適用
        SetCubeColor(cube, y);

        return y;
    }

    private void SetCubeColor(GameObject cube, float y)
    {
        MeshRenderer renderer = cube.GetComponent<MeshRenderer>();
        if (renderer == null) return;

        Material mat = new Material(Shader.Find("Standard")); // 新しいマテリアルを作成
        mat.color = GetColorByHeight(y);

        renderer.material = mat;
    }

    private Color GetColorByHeight(float y)
    {
        if (y > _maxHeight * 0.6f) return Color.red;
        if (y > _maxHeight * 0.3f) return Color.green;
        return Color.blue;
    }
}
