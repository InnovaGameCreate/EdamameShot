using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private GameObject _edamamePrefab;

    // �ێ����Ă���}��
    private GameObject _currentEdamame;

    // �}���̎��
    KindEdamame _kind;

    // �S�Ă̎}����Prefab
    [SerializeField] private GameObject NORMAL_EDAMAME_PREFAB;
    [SerializeField] private GameObject RAINBOW_EDAMAME_PREFAB;
    [SerializeField] private GameObject GOLDEN_EDAMAME_PREFAB;
    [SerializeField] private GameObject ROPE_EDAMAME_PREFAB;
    [SerializeField] private GameObject BLACK_EDAMAME_PREFAB;
    [SerializeField] private GameObject CLOCK_EDAMAME_PREFAB;
    [SerializeField] private GameObject ARROW_EDAMAME_PREFAB;

    // �c�e�̊Ǘ�����I�u�W�F�N�g
    [SerializeField] private GameObject _remainingEdamameMgrObj;
    private RemainingEdamameMgr _remainingEdamameMgr;

    // Start is called before the first frame update
    void Start()
    {
        _angleX = 30;
        _angleY = 30;

        _kind = KindEdamame.ClockEdamame;

        switch (_kind)
        {
            case KindEdamame.NormalEdamame:
                _edamamePrefab = NORMAL_EDAMAME_PREFAB; break;

            case KindEdamame.RainbowEdamame:
                _edamamePrefab = RAINBOW_EDAMAME_PREFAB; break;

            case KindEdamame.GoldenEdamame:
                _edamamePrefab = GOLDEN_EDAMAME_PREFAB; break;

            case KindEdamame.RopeEdamame:
                _edamamePrefab = ROPE_EDAMAME_PREFAB; break;

            case KindEdamame.BlackEdamame:
                _edamamePrefab = BLACK_EDAMAME_PREFAB; break;

            case KindEdamame.ClockEdamame:
                _edamamePrefab = CLOCK_EDAMAME_PREFAB; break;

            case KindEdamame.ArrowEdamame:
                _edamamePrefab = ARROW_EDAMAME_PREFAB; break;

            default:
                Debug.Log("Error"); break;
        }

        _currentEdamame = Instantiate(_edamamePrefab);// �}������

        _remainingEdamameMgr = _remainingEdamameMgrObj.GetComponent<RemainingEdamameMgr>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isShoot())
        {
            if (!_remainingEdamameMgr.DeleteRemainingEdamame())
                return;

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
    }

    public GameObject GetCurrentEdamame()
    {
        return _currentEdamame;
    }

    /// <summary>
    /// �p�x���擾(X)
    /// </summary>
    /// <returns> �p�x(X) </returns>
    public float GetAngleX() { return _angleX; }
    /// <summary>
    /// �p�x���擾(Y)
    /// </summary>
    /// <returns> �p�x(X) </returns>
    public float GetAngleY() { return _angleY; }
}
