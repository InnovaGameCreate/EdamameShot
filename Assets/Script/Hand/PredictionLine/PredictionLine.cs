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
    private float _accelX;
    private float _accelY;
    private float _accelZ;

    // PredictionLine
    private LineRenderer _lineRenderer;
    [SerializeField] private int _numLinePosition;

    // �ǂ̂��炢�o������
    float _time;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = _edamamePrefab.GetComponent<Rigidbody>();
        _mass = rb.mass;

        _edamameMgr = _hand.GetComponent<EdamameMgr>();
        
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = _numLinePosition;
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
        _impulseX = _currentEdamame.GetForceX();
        _impulseY = _currentEdamame.GetForceY();
        _impulseZ = _currentEdamame.GetForceZ();
        _angleX = _edamameMgr.GetAngleX();
        _angleY = _edamameMgr.GetAngleY();

        float radX = TranslateAngleToRad(_angleX);
        float radY = TranslateAngleToRad(_angleY);

        Rigidbody rb = _edamamePrefab.GetComponent<Rigidbody>();

        Vector3 impulse = new Vector3(_impulseX * Mathf.Cos(radX), _impulseY * Mathf.Sin(radY), _impulseZ);
        Vector3 initSpeed = impulse / _mass;
        Vector3 initPosition = rb.position;
        Vector3 gravity = new Vector3(0, -G, 0);
        
        float deltaTime = 0;
        for (int i = 0; i < _numLinePosition; ++i)
        {
            Vector3 position = initPosition + initSpeed * deltaTime + 0.5f * gravity * deltaTime * deltaTime;

            if (position.x > 3)
            {
                break;
            }
            _lineRenderer.SetPosition(i, position);
            deltaTime += Time.deltaTime;
        }
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
