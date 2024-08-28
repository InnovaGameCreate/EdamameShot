using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edamame : MonoBehaviour
{
    // 定数
    const float G = 9.8f * 0.1f; // 重力

    // 枝豆のパラメータ
    [SerializeField] float _speedX;
    [SerializeField] float _speedY;
    [SerializeField] float _speedZ;
    [SerializeField] float _angle;

    // どのくらい経ったか
    float _time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;


        if (!isOnTable())
        {
            float rad = translateAngleToRad(_angle);

            float deltaX = Mathf.Sin(rad * Time.deltaTime) * _speedX;
            float deltaZ = Mathf.Cos(rad * Time.deltaTime) * _speedZ;
            float deltaY = _speedY - (G * _time * _time) / 2;// Rigidbodyに変更予定
            
            this.transform.Translate(new Vector3(deltaX, deltaY, deltaZ));
        }
    }

    // テーブル(？)の上に乗る(条件)
    // isOnTriggerに変更するかもしれない
    bool isOnTable()
    {
        return transform.position.y < 0;
    }

    public void setAngle(float angle)
    {
        _angle = angle;
    }

    float translateAngleToRad(float angle)
    {
        return Mathf.PI / (180 / angle);
    }
}
