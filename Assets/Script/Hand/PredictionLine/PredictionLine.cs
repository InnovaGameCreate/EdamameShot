using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredictionLine : MonoBehaviour
{
    // �萔
    const float G = 9.81f; // �d��

    // �}��Prefab
    [SerializeField] private GameObject _edamamePrefab;

    // Hand
    [SerializeField] private GameObject _hand;

    // EdamameMgr
    private EdamameMgr _edamameMgr;

    // ���݂̎}��
    Edamame _currentEdamame;

    // �}���̃p�����[�^
    private float _angleX;
    private float _angleY;
    private float _mass;
    private float _impulseX;
    private float _impulseY;
    private float _impulseZ;

    // PredictionLine
    private LineRenderer _lineRenderer;
    [SerializeField] private int _maxLinePosition;
    [SerializeField] private float _maxPredictionLineDistance;

    // �ǂ̂��炢�o������
    float _time;


    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = _edamamePrefab.GetComponent<Rigidbody>();
        _mass = rb.mass;

        _edamameMgr = _hand.GetComponent<EdamameMgr>();
        
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = _maxLinePosition;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;

        DrawPredictionLine();// �O���\�����`��
    }

    private void DrawPredictionLine()
    {
        _currentEdamame = _edamameMgr.GetCurrentEdamame().GetComponent<Edamame>();
        if (HasHandChanged())   // �p�x���ύX���ꂽ�Ƃ�
        {
            // �e�l���擾
            _impulseX = _currentEdamame.GetImpulseX();
            _impulseY = _currentEdamame.GetImpulseY();
            _impulseZ = _currentEdamame.GetImpulseZ();
            _angleX = _edamameMgr.GetAngleX();
            _angleY = _edamameMgr.GetAngleY();

            // �p�x���ʓx�@�ɕϊ�
            float radX = TranslateAngleToRad(_angleX);
            float radY = TranslateAngleToRad(_angleY);

            Rigidbody rb = _edamamePrefab.GetComponent<Rigidbody>();

            // ���˂���Ƃ��̏Ռ�(�͐�)
            Vector3 impulse = new Vector3(_impulseX * Mathf.Cos(radX), _impulseY * Mathf.Sin(radY), _impulseZ);
            Vector3 initSpeed = impulse / _mass;
            Vector3 initPosition = rb.position;
            Vector3 gravity = new Vector3(0, -G, 0);
        
            // PredictionLine�̒���
            float allDistance = 0;
            // �S�Ă̓_
            List<Vector3> positions = new List<Vector3>();
            float z = 0;
            for (int i = 0; i < _maxLinePosition; ++i)
            {
                // z�����߂āC��������t���v�Z
                float deltaTime = Mathf.Sqrt((2 * (initPosition.z - z)) / -G);
                Vector3 position = initPosition + initSpeed * deltaTime + 0.5f * gravity * deltaTime * deltaTime;
                positions.Add(position);

                if (allDistance >= _maxPredictionLineDistance)  // �����̍ő�ɒB������I��
                {
                    break;
                }
                if (i > 0)
                {
                    allDistance += Vector3.Distance(positions.ToArray()[i - 1], position);    // �������v�Z
                }


                // z�𑝂₷
                z += 0.05f;
            }
            _lineRenderer.positionCount = positions.Count;   // LineRenderer�̐���ݒ�

            _lineRenderer.SetPositions(positions.ToArray()); // �_��ݒ�

        }
    }

    /// <summary>
    /// �p�x���ύX���ꂽ��
    /// </summary>
    /// <returns> bool </returns>
    private bool HasHandChanged()
    {
        return (_angleX != _edamameMgr.GetAngleX() || _angleY != _edamameMgr.GetAngleY());
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
    float TranslateAngleToRad(float angle)
    {
        return Mathf.PI / (180 / angle);
    }
}
