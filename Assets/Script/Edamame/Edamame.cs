using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Edamame : MonoBehaviour
{
    // Rigidbody
    private Rigidbody rb;

    // 定数
    const float G = 9.8f * 0.1f; // 重力

    // 枝豆のパラメータ
    [SerializeField] float _speedX;
    [SerializeField] float _speedY;
    [SerializeField] float _speedZ;
    [SerializeField] float _angle;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        PushObj();
    }

    private void PushObj()
    {
        // 角度を弧度法に変換
        float rad = TranslateAngleToRad(_angle);

        // 移動量を角度から計算
        float deltaX = Mathf.Sin(rad * Time.deltaTime) * _speedX;
        float deltaY = _speedY;
        float deltaZ = Mathf.Cos(rad * Time.deltaTime) * _speedZ;

        // 移動
        rb.AddForce(new Vector3(deltaX, deltaY, deltaZ), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 枝豆の角度を設定する
    /// </summary>
    /// <param name="angle"> 角度 </param>
    public void SetAngle(float angle)
    {
        _angle = angle;
    }

    /// <summary>
    /// 角度法を弧度法に変換
    /// </summary>
    /// <param name="angle"> 角度 </param>
    /// <returns></returns>
    float TranslateAngleToRad(float angle)
    {
        return Mathf.PI / (180 / angle);
    }
}
