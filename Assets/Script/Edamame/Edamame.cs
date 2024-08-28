using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Edamame : MonoBehaviour
{
    // Rigidbody
    private Rigidbody _rb;

    // 定数
    const float G = 9.8f * 0.1f; // 重力

    // 枝豆のパラメータ
    [SerializeField] private float _speedX;
    [SerializeField] private float _speedY;
    [SerializeField] private float _speedZ;
    private float _angle;

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
    /// <param name="angle"> 角度 </param>
    public void ShootEdamame(float angle)
    {
        // 角度設定
        SetAngle(angle);

        // 角度を弧度法に変換
        float rad = TranslateAngleToRad(_angle);

        // 移動量を角度から計算
        float deltaX = Mathf.Cos(rad) * _speedX;
        float deltaY = _speedY;
        float deltaZ = Mathf.Sin(rad) * _speedZ;

        // 重力適用
        _rb.useGravity = true;
        // 移動
        _rb.AddForce(new Vector3(deltaX, deltaY, deltaZ), ForceMode.Impulse);

        // 当たり判定有効か
        gameObject.GetComponent<Collider>().enabled = true;
    }

    /// <summary>
    /// 枝豆の角度の設定
    /// </summary>
    /// <param name="angle"> 角度 </param>
    public void SetAngle(float angle)
    {
        if (angle < 0)
        {
            _angle *= -1;
        }
        if (angle > 180)
        {
            _angle = 360 - angle;
        }

        _angle = angle;
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
}
