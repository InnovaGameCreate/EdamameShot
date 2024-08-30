using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredictionLine : MonoBehaviour
{
    // 定数
    const float G = 9.81f; // 重力

    // 枝豆Prefab
    [SerializeField] private GameObject _edamamePrefab;

    // Hand
    [SerializeField] private GameObject _hand;

    // EdamameMgr
    private EdamameMgr _edamameMgr;

    // 現在の枝豆
    Edamame _currentEdamame;

    // 枝豆のパラメータ
    private float _angleX;
    private float _angleY;
    private float _mass;
    private float _impulseX;
    private float _impulseY;
    private float _impulseZ;

    // PredictionLine
    private LineRenderer _lineRenderer;
    [SerializeField] private int _maxLinePosition;
    [SerializeField] private float _maxPredictionLineDistance;

    // どのくらい経ったか
    float _time;


    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = _edamamePrefab.GetComponent<Rigidbody>();
        _mass = rb.mass;

        _edamameMgr = _hand.GetComponent<EdamameMgr>();
        
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = _maxLinePosition;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;

        DrawPredictionLine();// 軌道予測線描画
    }

    private void DrawPredictionLine()
    {
        _currentEdamame = _edamameMgr.GetCurrentEdamame().GetComponent<Edamame>();
        if (HasHandChanged())   // 角度が変更されたとき
        {
            // 各値を取得
            _impulseX = _currentEdamame.GetImpulseX();
            _impulseY = _currentEdamame.GetImpulseY();
            _impulseZ = _currentEdamame.GetImpulseZ();
            _angleX = _edamameMgr.GetAngleX();
            _angleY = _edamameMgr.GetAngleY();

            // 角度を弧度法に変換
            float radX = TranslateAngleToRad(_angleX);
            float radY = TranslateAngleToRad(_angleY);

            Rigidbody rb = _edamamePrefab.GetComponent<Rigidbody>();

            // 発射するときの衝撃(力積)
            Vector3 impulse = new Vector3(_impulseX * Mathf.Cos(radX), _impulseY * Mathf.Sin(radY), _impulseZ);
            Vector3 initSpeed = impulse / _mass;
            Vector3 initPosition = rb.position;
            Vector3 gravity = new Vector3(0, -G, 0);
        
            // PredictionLineの長さ
            float allDistance = 0;
            // 全ての点
            List<Vector3> positions = new List<Vector3>();
            float z = 0;
            for (int i = 0; i < _maxLinePosition; ++i)
            {
                // zを決めて，そこからtを計算
                float deltaTime = Mathf.Sqrt((2 * (initPosition.z - z)) / -G);
                Vector3 position = initPosition + initSpeed * deltaTime + 0.5f * gravity * deltaTime * deltaTime;
                positions.Add(position);

                if (allDistance >= _maxPredictionLineDistance)  // 長さの最大に達したら終了
                {
                    break;
                }
                if (i > 0)
                {
                    allDistance += Vector3.Distance(positions.ToArray()[i - 1], position);    // 長さを計算
                }


                // zを増やす
                z += 0.05f;
            }
            _lineRenderer.positionCount = positions.Count;   // LineRendererの数を設定

            _lineRenderer.SetPositions(positions.ToArray()); // 点を設定

        }
    }

    /// <summary>
    /// 角度が変更されたか
    /// </summary>
    /// <returns> bool </returns>
    private bool HasHandChanged()
    {
        return (_angleX != _edamameMgr.GetAngleX() || _angleY != _edamameMgr.GetAngleY());
    }

    /// <summary>
    /// 枝豆の角度の設定
    /// </summary>
    /// <param name="angleX"> 横の角度 </param>
    /// <param name="angleY"> 縦の角度 </param>
    public void SetAngle(float angleX, float angleY)
    {
        if (angleX < 0)
        {
            angleX *= -1;
        }
        if (angleX > 180)
        {
            angleX = 360 - angleX;
        }

        if (angleY < 0)
        {
            angleY *= -1;
        }
        if (angleY > 180)
        {
            angleY = 360 - angleY;
        }

        _angleX = angleX;
        _angleY = angleY;
    }

    /// <summary>
    /// 角度法を弧度法に変換
    /// </summary>
    /// <param name="angle"> 角度(角度法) </param>
    /// <returns> 角度(弧度法) </returns>
    float TranslateAngleToRad(float angle)
    {
        return Mathf.PI / (180 / angle);
    }
}
