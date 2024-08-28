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
    private float _angle;

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
    /// <param name="angle"> �p�x </param>
    public void ShootEdamame(float angle)
    {
        // �p�x�ݒ�
        SetAngle(angle);

        // �p�x���ʓx�@�ɕϊ�
        float rad = TranslateAngleToRad(_angle);

        // �ړ��ʂ��p�x����v�Z
        float deltaX = Mathf.Cos(rad) * _speedX;
        float deltaY = _speedY;
        float deltaZ = Mathf.Sin(rad) * _speedZ;

        // �d�͓K�p
        _rb.useGravity = true;
        // �ړ�
        _rb.AddForce(new Vector3(deltaX, deltaY, deltaZ), ForceMode.Impulse);

        // �����蔻��L����
        gameObject.GetComponent<Collider>().enabled = true;
    }

    /// <summary>
    /// �}���̊p�x�̐ݒ�
    /// </summary>
    /// <param name="angle"> �p�x </param>
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
    /// �p�x�@���ʓx�@�ɕϊ�
    /// </summary>
    /// <param name="angle"> �p�x(�p�x�@) </param>
    /// <returns> �p�x(�ʓx�@) </returns>
    private float TranslateAngleToRad(float angle)
    {
        return Mathf.PI / (180 / angle);
    }
}
