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
    private float _forceX;
    private float _forceY;
    private float _forceZ;
    private float _accelX;
    private float _accelY;
    private float _accelZ;

    // PredictionLine
    private LineRenderer _lineRenderer;
    [SerializeField] private int _numLinePosition;

    // どのくらい経ったか
    float _time;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = _edamamePrefab.GetComponent<Rigidbody>();
        _mass = rb.mass;

        _edamameMgr = _hand.GetComponent<EdamameMgr>();
        
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = _numLinePosition;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;

        DrawPredictionLine();// 軌道予測線描画
    }

    private void DrawPredictionLine()
    {
        _currentEdamame = _edamameMgr.GetComponent<EdamameMgr>().GetCurrentEdamame().GetComponent<Edamame>();
        _forceX = _currentEdamame.GetForceX();
        _forceY = _currentEdamame.GetForceY();
        _forceZ = _currentEdamame.GetForceZ();
        _angleX = _currentEdamame.GetAngleX();
        _angleY = _currentEdamame.GetAngleY();

        float radX = TranslateAngleToRad(_angleX);
        float radY = TranslateAngleToRad(_angleY);

        _accelX = _forceX / _mass;
        _accelY = ((_forceY * Mathf.Sin(radY)) / _mass) - G;
        _accelZ = _forceZ;
        
        float deltaTime = 0;
        for (int i = 0; i < _numLinePosition; ++i)
        {
            float x = _accelX * Mathf.Cos(radX) * deltaTime * deltaTime / 2;
            float y = _accelY * Mathf.Sin(radY) * deltaTime * deltaTime / 2;
            float z = _accelZ * deltaTime * deltaTime / 2;

            _lineRenderer.SetPosition(i, new Vector3(x, y, z));
            deltaTime += Time.deltaTime * 100;

            Debug.Log($"x: {x}\ny: {y}\nz: {z}");
        }
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
