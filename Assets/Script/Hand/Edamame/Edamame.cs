using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Edamame : MonoBehaviour
{
    // Rigidbody
    private Rigidbody _rb;

    // �萔
    const float G = 9.8f * 0.1f; // �d��

    // �}���̃p�����[�^
    [SerializeField] private float _speedX;
    [SerializeField] private float _speedY;
    [SerializeField] private float _speedZ;
    private float _angleX;
    private float _angleY;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false; // �����Ȃ��悤�ɐݒ�

        // �����蔻�薳����
        gameObject.GetComponent<Collider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// �}������
    /// </summary>
    /// <param name="angleX"> ���̊p�x </param>
    /// <param name="angleY"> �c�̊p�x </param>
    public void ShootEdamame(float angleX, float angleY)
    {
        // �p�x�ݒ�
        SetAngle(angleX, angleY);

        // �p�x���ʓx�@�ɕϊ�
        float radX = TranslateAngleToRad(_angleX);
        float radY = TranslateAngleToRad(_angleY);

        // �ړ��ʂ��p�x����v�Z
        float deltaX = Mathf.Cos(radX) * _speedX;
        float deltaY = Mathf.Sin(radY) * _speedY;
        float deltaZ = Mathf.Sin(radX) * _speedZ;

        // �d�͂�K�p
        _rb.useGravity = true;
        // �ړ�
        _rb.AddForce(new Vector3(deltaX, deltaY, deltaZ), ForceMode.Impulse);

        // �����蔻��L����
        gameObject.GetComponent<Collider>().enabled = true;
    }

    /// <summary>
    /// �}���̊p�x�̐ݒ�
    /// </summary>
    /// <param name="angleX"> ���̊p�x </param>
    /// <param name="angleY"> �c�̊p�x </param>
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
    /// �p�x�@���ʓx�@�ɕϊ�
    /// </summary>
    /// <param name="angle"> �p�x(�p�x�@) </param>
    /// <returns> �p�x(�ʓx�@) </returns>
    private float TranslateAngleToRad(float angle)
    {
        return Mathf.PI / (180 / angle);
    }
}
