using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredictionLine : MonoBehaviour
{
    // 定数
    const float G = 9.8f * 0.1f; // 重力

    // 枝豆Prefab
    [SerializeField] private GameObject _edamamePrefab;

    // 現在の枝豆
    Edamame _currentEdamame;

    // 枝豆のパラメータ
    [SerializeField] private float _speedX;
    [SerializeField] private float _speedY;
    [SerializeField] private float _speedZ;
    private float _angleX;
    private float _angleY;
    private float _mass;
    private float _forceX;
    private float _forceY;

    // どのくらい経ったか
    float _time;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = _edamamePrefab.GetComponent<Rigidbody>();
        _mass = rb.mass;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;

        _currentEdamame = _edamamePrefab.GetComponent<Edamame>();
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

    float translateAngleToRad(float angle)
    {
        return Mathf.PI / (180 / angle);
    }
}
