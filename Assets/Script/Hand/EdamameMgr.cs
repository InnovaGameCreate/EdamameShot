using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdamameMgr : MonoBehaviour
{
    // �p�x�͈̔�
    public const float ANGLE_X_MIN = 30;
    public const float ANGLE_X_MAX = 150;
    public const float ANGLE_Y_MIN = 10;
    public const float ANGLE_Y_MAX = 80;

    // �p�x
    private float _angleX;
    private float _angleY;

    // �ǂꂾ�����Ŋp�x�𓮂�����
    [SerializeField] private float _speedAngle;

    // �}��Prefab
    [SerializeField] private GameObject _edamamePrefab;

    // �ێ����Ă���}��
    private GameObject _currentEdamame;

    // Start is called before the first frame update
    void Start()
    {
        _angleX = 30;
        _angleY = 30;
        _currentEdamame = Instantiate(_edamamePrefab);// �}������
    }

    // Update is called once per frame
    void Update()
    {
        if (isShoot())
        {
            Edamame edamame = _currentEdamame.GetComponent<Edamame>();
            edamame.ShootEdamame(_angleX, _angleY);// �}������

            _currentEdamame = Instantiate(_edamamePrefab);// �V�����}������
        }

        // �p�x����
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _angleX += _speedAngle * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _angleX -= _speedAngle * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _angleY += _speedAngle * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _angleY -= _speedAngle * Time.deltaTime;
        }
        CheckAngleRange();  // �p�x�𐧌�
    }

    /// <summary>
    /// �}���𔭎˂��邩
    /// </summary>
    /// <returns> true: �X�y�[�X�L�[�������ꂽ�Ƃ�, false: �X�y�[�X�L�[��������Ă��Ȃ��Ƃ�</returns>
    bool isShoot()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    /// <summary>
    /// �ݒ肳�ꂽ�p�x���L�����`�F�b�N
    /// </summary>
    void CheckAngleRange()
    {
        if (_angleX < ANGLE_X_MIN)
        {
            _angleX = ANGLE_X_MIN;
        }
        if (_angleX > ANGLE_X_MAX)
        {
            _angleX = ANGLE_X_MAX;
        }
        if (_angleY < ANGLE_Y_MIN)
        {
            _angleY = ANGLE_Y_MIN;
        }
        if (_angleY > ANGLE_Y_MAX)
        {
            _angleY = ANGLE_Y_MAX;
        }


        Debug.Log("angleX: " + _angleX);
        Debug.Log("angleY: " + _angleY);
    }
}