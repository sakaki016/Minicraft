using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    Sequence sequence;
    //sequenceが動いているか
    private bool _isSeqKill = false;
    //手は動いているか
    private bool _isMove = false;

    private void Start()
    {
        sequence = DOTween.Sequence();
    }

    private void Update()
    {
        //左クリックの動作
        if (Input.GetMouseButtonDown(0) && _isSeqKill)
        {
            sequence = DOTween.Sequence();

            sequence.Append(transform.DOLocalMove(new Vector3(0.5f, -0.4f, 0.25f), 0.01f))
                    .Append(transform.DOLocalMove(new Vector3(0.0f, -0.35f, 0.15f), 0.05f))
                    .Append(transform.DOLocalMove(new Vector3(0.0f, -0.5f, 0.212f), 0.1f))
                    .Append(transform.DOLocalMove(new Vector3(0.284f, -0.477f, 0.212f), 0.2f));

            sequence.Play().SetLoops(-1, LoopType.Restart);
            _isSeqKill = false;
            _isMove = true;
        }
        if (Input.GetMouseButtonUp(0) && !_isSeqKill)
        {
            transform.DOLocalMove(new Vector3(0.284f, -0.477f, 0.212f), 0.1f).OnComplete(() =>
            {
                this.sequence.Kill();
                _isSeqKill = true;
                _isMove = false;
            });
        }
        //右クリックの動作
        if (Input.GetMouseButtonDown(1) && _isSeqKill)
        {
            sequence = DOTween.Sequence();

            sequence.Append(transform.DOLocalMove(new Vector3(0.5f, -0.4f, 0.25f), 0.01f))
                    .Append(transform.DOLocalMove(new Vector3(0.0f, -0.35f, 0.15f), 0.05f))
                    .Append(transform.DOLocalMove(new Vector3(0.0f, -0.5f, 0.212f), 0.1f))
                    .Append(transform.DOLocalMove(new Vector3(0.284f, -0.477f, 0.212f), 0.2f));

            sequence.Play();
            _isSeqKill = false;
            _isMove = true;
        }
        if (Input.GetMouseButtonUp(1) && !_isSeqKill)
        {
            transform.DOLocalMove(new Vector3(0.284f, -0.477f, 0.212f), 0.1f).OnComplete(() =>
            {
                this.sequence.Kill();
                _isSeqKill = true;
                _isMove = false;
            });
        }
    }
    public bool IsMoving()
    {
        return _isMove;
    }
}
