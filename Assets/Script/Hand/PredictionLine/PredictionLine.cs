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
        _currentEdamame = _edamameMgr.GetCurrentEdamame().GetComponent<Edamame>();
        _impulseX = _currentEdamame.GetForceX();
        _impulseY = _currentEdamame.GetForceY();
        _impulseZ = _currentEdamame.GetForceZ();
        _angleX = _edamameMgr.GetAngleX();
        _angleY = _edamameMgr.GetAngleY();

        float radX = TranslateAngleToRad(_angleX);
        float radY = TranslateAngleToRad(_angleY);

        Rigidbody rb = _edamamePrefab.GetComponent<Rigidbody>();

        Vector3 impulse = new Vector3(_impulseX * Mathf.Cos(radX), _impulseY * Mathf.Sin(radY), _impulseZ);
        Vector3 initSpeed = impulse / _mass;
        Vector3 initPosition = rb.position;
        Vector3 gravity = new Vector3(0, -G, 0);
        
        float deltaTime = 0;
        for (int i = 0; i < _numLinePosition; ++i)
        {
            Vector3 position = initPosition + initSpeed * deltaTime + 0.5f * gravity * deltaTime * deltaTime;

            if (position.x > 3)
            {
                break;
            }
            _lineRenderer.SetPosition(i, position);
            deltaTime += Time.deltaTime;
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
