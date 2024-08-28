using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Edamame : MonoBehaviour
{
    // Rigidbody
    private Rigidbody rb;

    // �萔
    const float G = 9.8f * 0.1f; // �d��

    // �}���̃p�����[�^
    [SerializeField] float _speedX;
    [SerializeField] float _speedY;
    [SerializeField] float _speedZ;
    [SerializeField] float _angle;

    // �ǂ̂��炢�o������
    float _time;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        PushObj();
    }

    private void PushObj()
    {
        float rad = TranslateAngleToRad(_angle);

        float deltaX = Mathf.Sin(rad * Time.deltaTime) * _speedX;
        float deltaY = _speedY;
        float deltaZ = Mathf.Cos(rad * Time.deltaTime) * _speedZ;

        rb.AddForce(new Vector3(deltaX, deltaY, deltaZ), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
    }

    /// <summary>
    /// �}���̊p�x��ݒ肷��
    /// </summary>
    /// <param name="angle"> �p�x </param>
    public void SetAngle(float angle)
    {
        _angle = angle;
    }

    /// <summary>
    /// �p�x�@���ʓx�@�ɕϊ�
    /// </summary>
    /// <param name="angle"> �p�x </param>
    /// <returns></returns>
    float TranslateAngleToRad(float angle)
    {
        return Mathf.PI / (180 / angle);
    }
}
