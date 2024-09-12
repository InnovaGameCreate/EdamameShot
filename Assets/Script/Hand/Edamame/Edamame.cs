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
    // ���̎}����
    KindEdamame _kind;

    // Rigidbody
    private Rigidbody _rb;

    // �}���̃p�����[�^
    [SerializeField] private float _impulseX;
    [SerializeField] private float _impulseY;
    [SerializeField] private float _impulseZ;
    private float _angleX;
    private float _angleY;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        // �����蔻�薳����
        gameObject.GetComponent<Collider>().enabled = false;

        // �f�t�H���g�͕��ʂ̎}��
        _kind = KindEdamame.NormalEdamame;
    }

    // Update is called once per frame
    void Update()
    {
        // �����čs������폜
        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
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
        float deltaX = Mathf.Cos(radX) * _impulseX;
        float deltaY = Mathf.Sin(radY) * _impulseY;
        float deltaZ = _impulseZ;

        // �d�͂�K�p
        _rb.useGravity = true;
        // ����
        _rb.AddForce(new Vector3(deltaX, deltaY, deltaZ), ForceMode.Impulse);

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Basket")
        {
            Destroy(gameObject);
        }
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

    public void SetKind(KindEdamame kind)
    {
        _kind = kind;
    }
    public KindEdamame GetKind()
    {
        return _kind;
    }

    /// <summary>
    /// �}���𔭎˂���p�x(X)
    /// </summary>
    /// <returns> �p�x(X) </returns>
    public float GetAngleX() { return _angleX; }
    /// <summary>
    /// �}���𔭎˂���p�x(Y)
    /// </summary>
    /// <returns> �p�x(Y) </returns>
    public float GetAngleY() { return _angleY; }

    /// <summary>
    /// �}���𔭎˂����(X)
    /// </summary>
    /// <returns> ��(X) </returns>
    public float GetImpulseX() { return _impulseX; }
    /// <summary>
    /// �}���𔭎˂����(Y)
    /// </summary>
    /// <returns> ��(Y) </returns>
    public float GetImpulseY() { return _impulseY; }
    /// <summary>
    /// �}���𔭎˂����(Z)
    /// </summary>
    /// <returns> ��(Z) </returns>
    public float GetImpulseZ() { return _impulseZ; }
}
