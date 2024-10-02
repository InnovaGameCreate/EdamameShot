using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum KindEdamame { 
    NormalEdamame,
    RainbowEdamame,
    GoldenEdamame,
    RopeEdamame,
    BlackEdamame,
    ClockEdamame,
    ArrowEdamame
};

public class Edamame : MonoBehaviour
{
    // Rigidbody
    private Rigidbody _rb;

    // 枝豆のパラメータ
    [SerializeField] private float _impulseX;
    [SerializeField] private float _impulseY;
    [SerializeField] private float _impulseZ;
    private float _angleX;
    private float _angleY;

    private Fever _fever;
    private GameObject _basketObj;

    private bool _isActiveFever;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        // 当たり判定無効化
        //gameObject.GetComponent<Collider>().enabled = false;

        _isActiveFever = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 落ちて行ったら削除
        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
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
        float deltaX = Mathf.Cos(radX) * _impulseX;
        float deltaY = Mathf.Sin(radY) * _impulseY;
        float deltaZ = _impulseZ;

        // 重力を適用
        _rb.useGravity = true;
        // 発射
        _rb.AddForce(new Vector3(deltaX, deltaY, deltaZ), ForceMode.Impulse);

        gameObject.GetComponent<Collider>().enabled = true;
    }

    public bool GetIsActiveFever()
    {
        return _isActiveFever;
    }

    public void SetIsActiveFever(bool isactive)
    {
        _isActiveFever = isactive;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Basket")
        {
            Destroy(gameObject);
        }
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
    public float GetImpulseX() { return _impulseX; }
    /// <summary>
    /// 枝豆を発射する力(Y)
    /// </summary>
    /// <returns> 力(Y) </returns>
    public float GetImpulseY() { return _impulseY; }
    /// <summary>
    /// 枝豆を発射する力(Z)
    /// </summary>
    /// <returns> 力(Z) </returns>
    public float GetImpulseZ() { return _impulseZ; }
}