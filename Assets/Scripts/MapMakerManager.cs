using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// �����_���Ƀ}�b�v�𐶐�����N���X
/// </summary>
public class MapMakerManager : MonoBehaviour
{
    // �V�[�h�l�i�m�C�Y�p�j
    private float _seedX, _seedZ;

    [SerializeField]
    [Header("------���s���ɕς���Ȃ�------")]
    private float _width = 50; // �}�b�v�̕�
    [SerializeField]
    private float _depth = 50; // �}�b�v�̉��s��

    [SerializeField]
    private bool _needToCollider = false; // �R���C�_�[�����邩�ǂ���

    [SerializeField]
    [Header("------���s���ɕς�����------")]
    private float _maxHeight = 10; // �ő卂��

    [SerializeField]
    private bool _isPerlinNoiseMap = true; // �p�[�����m�C�Y���g����

    [SerializeField]
    private float _relief = 15f; // �N���̌�����

    [SerializeField]
    private bool _isSmoothness = false; // ���������炩�ɂ��邩

    [SerializeField]
    private float _mapSize = 1f; // �}�b�v�̃X�P�[��

    private void Awake()
    {
        // �}�b�v�̃X�P�[���ݒ�
        transform.localScale = new Vector3(_mapSize, _mapSize, _mapSize);

        // �V�[�h�l�̏������i�m�C�Y�Ŏg���j
        _seedX = Random.value * 100f;
        _seedZ = Random.value * 100f;

        // �}�b�v�̐���
        for (int x = 0; x < _width; x++)
        {
            for (int z = 0; z < _depth; z++)
            {
                // �L���[�u�𐶐�
                GameObject topCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                topCube.transform.localPosition = new Vector3(x, 0, z);
                topCube.transform.SetParent(transform);

                // �R���C�_�[���s�v�Ȃ�폜
                if (!_needToCollider)
                {
                    Destroy(topCube.GetComponent<BoxCollider>());
                }

                // ������ݒ�
                float topY = SetY(topCube);

                // Y���W�̒��_���� y = -20 �܂ŃL���[�u��ςݏグ��
                for (float y = topY - 1; y >= -5; y--)
                {
                    GameObject underCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    underCube.transform.localPosition = new Vector3(x, y, z);
                    underCube.transform.SetParent(transform);

                    // �R���C�_�[���s�v�Ȃ�폜
                    if (!_needToCollider)
                    {
                        Destroy(underCube.GetComponent<BoxCollider>());
                    }

                    // �n�ʂ̐F��ݒ�
                    underCube.GetComponent<MeshRenderer>().material.color = Color.gray;
                }
            }
        }
    }

    private void OnValidate()
    {
        // ���s���łȂ���Ώ������Ȃ�
        if (!Application.isPlaying)
        {
            return;
        }

        // �}�b�v�̃X�P�[�����X�V
        transform.localScale = new Vector3(_mapSize, _mapSize, _mapSize);

        // ���ׂĂ̎q�I�u�W�F�N�g�i�L���[�u�j��Y���W���X�V
        foreach (Transform child in transform)
        {
            SetY(child.gameObject);
        }
    }

    /// <summary>
    /// �L���[�u��Y���W��ݒ肷��
    /// </summary>
    /// <param name="cube">�Ώۂ̃L���[�u</param>
    /// <returns>�ݒ肳�ꂽY���W</returns>
    private float SetY(GameObject cube)
    {
        float y = 0;

        // �p�[�����m�C�Y�𗘗p���č���������
        if (_isPerlinNoiseMap)
        {
            float xSample = (cube.transform.localPosition.x + _seedX) / _relief;
            float zSample = (cube.transform.localPosition.z + _seedZ) / _relief;
            float noise = Mathf.PerlinNoise(xSample, zSample);
            y = _maxHeight * noise;
        }
        else
        {
            // ���S�����_���ȍ���
            y = Random.Range(0, _maxHeight);
        }

        // �����𐮐��l�Ɋۂ߂�i���炩�łȂ��ꍇ�j
        if (!_isSmoothness)
        {
            y = Mathf.Round(y);
        }

        // �L���[�u�̈ʒu��ݒ�
        cube.transform.localPosition = new Vector3(cube.transform.localPosition.x, y, cube.transform.localPosition.z);

        // �����ɉ������F��ݒ�
        Color color = Color.black;
        if (y > _maxHeight * 0.3f)
        {
            ColorUtility.TryParseHtmlString("#965042", out color); // �y���ۂ��F
        }
        else if (y > _maxHeight * 0.1f)
        {
            ColorUtility.TryParseHtmlString("#7d7d7d", out color); // �����ۂ��F
        }
        //else if (y > _maxHeight * 0.1f)
        //{
        //    ColorUtility.TryParseHtmlString("#D4500EFF", out color); // �}�O�}���ۂ��F
        //}
        cube.GetComponent<MeshRenderer>().material.color = color;
        return y;
    }
}
