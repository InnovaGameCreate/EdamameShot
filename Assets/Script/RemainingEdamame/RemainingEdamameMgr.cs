using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainingEdamameMgr : MonoBehaviour
{
    // 残弾を表示する画像
    private GameObject[] _remainingEdamameImgMasksObj;

    // 残弾
    private int _numRemainingEdamame;

    // 残弾の上限
    [SerializeField] private int _maxRemainingEdamame;

    // 残弾が増える時間
    [SerializeField] private float _intervalRemainingTime;

    // 経過した時間
    private float _time;

    // マスクを動かす範囲
    [SerializeField] private float _maxMaskBottom;
    [SerializeField] private float _minMaskBottom;

    // マスクのスピード
    private float _speedChangeBottom;

    // Start is called before the first frame update
    void Start()
    {
        _remainingEdamameImgMasksObj = new GameObject[_maxRemainingEdamame];
        _numRemainingEdamame = _maxRemainingEdamame;
        _speedChangeBottom = _maxMaskBottom - _minMaskBottom;
        _time = 0;

        // マスクを取得し，位置を初期化
        for (int i = 0; i < _maxRemainingEdamame; ++i)
        {
            _remainingEdamameImgMasksObj[i] = GameObject.Find($"Mask{3 - i}");
            _remainingEdamameImgMasksObj[i].GetComponent<RectMask2D>().padding = new Vector3(0, _minMaskBottom, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_numRemainingEdamame < _maxRemainingEdamame)
        {
            _time += Time.deltaTime;

            DrawNewRemainingEdamame();
            if (_time >= _intervalRemainingTime)// 1秒経ったら1つ回復
            {
                _numRemainingEdamame++;
                _time = 0;
            }
        }
    }

    /// <summary>
    /// 一番最新の枝豆の残弾の画像についての処理
    /// </summary>
    private void DrawNewRemainingEdamame()
    {
        _remainingEdamameImgMasksObj[2 - _numRemainingEdamame].GetComponent<RectMask2D>().padding =
            new Vector4(0, _maxMaskBottom - _speedChangeBottom * _time, 0, 0);
    }

    /// <summary>
    /// 残りの枝豆を減らす
    /// </summary>
    /// <returns> true: 成功, false: 失敗(残弾が足りない) </returns>
    public bool DeleteRemainingEdamame()
    {
        // 残弾数が0のとき発射しない
        if (_numRemainingEdamame < 1)
        {
            return false;
        }

        _numRemainingEdamame--;// 残弾を減らす

        // 残弾の画像を隠す
        for (int i = 2 - _numRemainingEdamame; i >= 0; --i)
        {
            _remainingEdamameImgMasksObj[i].GetComponent<RectMask2D>().padding = new Vector4(0, _maxMaskBottom, 0, 0);
        }
        _time = 0;

        return true;
    }
}
