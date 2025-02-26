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
    private float _minHeight = -5; // 底（岩盤）

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

    // 新たにPrefabを参照するための変数
    [SerializeField] private GameObject grassPrefab; // 草のPrefab
    [SerializeField] private GameObject dirtPrefab; // 土のPrefab
    [SerializeField] private GameObject rockPrefab; // 石のPrefab
    [SerializeField] private GameObject brickPrefab; // 岩盤のPrefab

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
                // 高さを設定してPrefabを選ぶ
                GameObject tile = CreateTile(x, 0, z);
                tile.transform.SetParent(transform);
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

        // すべての子オブジェクト（Prefab）のY座標を更新
        foreach (Transform child in transform)
        {
            SetY(child.gameObject);
        }
    }

    private GameObject CreateTile(int x, int y, int z)
    {
        // 初期Prefabを決定
        GameObject prefab = grassPrefab;  // 初期のPrefabを草ブロックに設定
        GameObject tile = Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity);

        // コライダーが不要なら削除
        if (!_needToCollider)
        {
            Destroy(tile.GetComponent<Collider>());
        }

        // 高さを設定してPrefabを変更
        float topY = SetY(tile);  // SetYで高さを設定
        tile.transform.localPosition = new Vector3(x, topY, z);  // Y座標を更新

        // 各タイルの高さに応じてPrefabを変更
        for (float height = topY - 1; height >= _minHeight; height--)
        {
            prefab = GetPrefabByHeight(height); // 高さに応じてPrefabを更新
            GameObject underTile = Instantiate(prefab, new Vector3(x, height, z), Quaternion.identity);
            underTile.transform.SetParent(transform);

            // コライダーが不要なら削除
            if (!_needToCollider)
            {
                Destroy(underTile.GetComponent<Collider>());
            }
        }

        return tile;
    }

    private float SetY(GameObject tile)
    {
        float y = 0;

        if (_isPerlinNoiseMap)
        {
            float xSample = (tile.transform.localPosition.x + _seedX) / _relief;
            float zSample = (tile.transform.localPosition.z + _seedZ) / _relief;
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

        tile.transform.localPosition = new Vector3(tile.transform.localPosition.x, y, tile.transform.localPosition.z);

        return y;
    }

    private GameObject GetPrefabByHeight(float height)
    {
        // 高さに応じて異なるPrefabを返す
        if (height > _maxHeight - 10) // 土
        {
            return dirtPrefab;
        }
        else if (height == _minHeight) // 岩盤
        {
            return brickPrefab;
        }
        else  // 石
        {
            return rockPrefab;
        }
    }
}