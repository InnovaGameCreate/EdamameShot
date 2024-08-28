using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdamameMgr : MonoBehaviour
{
    // �p�x�͈̔�
    public const float ANGLE_MIN = 30;
    public const float ANGLE_MAX = 150;

    // �p�x
    private float _angle;

    // �ǂꂾ�����Ŋp�x�𓮂�����
    [SerializeField] private float _speedAngle;

    // �}��Prefab
    [SerializeField] private GameObject _edamamePrefab;

    // �ێ����Ă���}��
    private GameObject _currentEdamame;

    // Start is called before the first frame update
    void Start()
    {
        _angle = 30;
        _currentEdamame = Instantiate(_edamamePrefab);// �}������
    }

    // Update is called once per frame
    void Update()
    {
        if (isShoot())
        {
            Edamame edamame = _currentEdamame.GetComponent<Edamame>();
            edamame.ShootEdamame(_angle);// �}������

            _currentEdamame = Instantiate(_edamamePrefab);// �V�����}������
        }

        // �p�x����
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _angle += _speedAngle * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _angle -= _speedAngle * Time.deltaTime;
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
        if (_angle < ANGLE_MIN)
        {
            _angle = ANGLE_MIN;
        }
        if (_angle > ANGLE_MAX)
        {
            _angle = ANGLE_MAX;
        }

        Debug.Log("angle: " + _angle);
    }
}
