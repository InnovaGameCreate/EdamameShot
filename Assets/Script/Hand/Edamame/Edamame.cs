using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Edamame : MonoBehaviour
{
    // Rigidbody
    private Rigidbody _rb;

    // 枝豆のパラメータ
    [SerializeField] private float _forceX;
    [SerializeField] private float _forceY;
    [SerializeField] private float _forceZ;
    private float _angleX;
    private float _angleY;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false; // 落ちないように設定

        // 当たり判定無効化
        gameObject.GetComponent<Collider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// 枝豆発射
    /// </summary>
    /// <param name="angleX"> 横の角度 </param>
    /// <param name="angleY"> 縦の角度 </param>
    public void ShootEdamame(float angleX, float angleY)
    {
        // 角度設定
        SetAngle(angleX, angleY);

        // 角度を弧度法に変換
        float radX = TranslateAngleToRad(_angleX);
        float radY = TranslateAngleToRad(_angleY);

        // 移動量を角度から計算
        float deltaX = Mathf.Cos(radX) * _forceX;
        float deltaY = Mathf.Sin(radY) * _forceY;
        float deltaZ = _forceZ;

        // 重力を適用
        _rb.useGravity = true;
        // 発射
        _rb.AddForce(new Vector3(deltaX, deltaY, deltaZ), ForceMode.Impulse);

        // 当たり判定有効か
        gameObject.GetComponent<Collider>().enabled = true;
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
    private float TranslateAngleToRad(float angle)
    {
        return Mathf.PI / (180 / angle);
    }

    /// <summary>
    /// 枝豆を発射する角度(X)
    /// </summary>
    /// <returns> 角度(X) </returns>
    public float GetAngleX() { return _angleX; }
    /// <summary>
    /// 枝豆を発射する角度(Y)
    /// </summary>
    /// <returns> 角度(Y) </returns>
    public float GetAngleY() { return _angleY; }

    /// <summary>
    /// 枝豆を発射する力(X)
    /// </summary>
    /// <returns> 力(X) </returns>
    public float GetForceX() { return _forceX; }
    /// <summary>
    /// 枝豆を発射する力(Y)
    /// </summary>
    /// <returns> 力(Y) </returns>
    public float GetForceY() { return _forceY; }
    /// <summary>
    /// 枝豆を発射する力(Z)
    /// </summary>
    /// <returns> 力(Z) </returns>
    public float GetForceZ() { return _forceZ; }
}
