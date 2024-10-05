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

    // �}���̏o��m��
    [SerializeField] private int[] _howEdamameShow;
    private int[] _howEdamameRandRange;

    // �c�e�̊Ǘ�����I�u�W�F�N�g
    [SerializeField] private GameObject _remainingEdamameMgrObj;
    private RemainingEdamameMgr _remainingEdamameMgr;

    // �����̎}����z�u����͈�
    [SerializeField] private float EDAMAME_RANGE_W;
    [SerializeField] private float EDAMAME_RANGE_H;

    // Start is called before the first frame update
    void Start()
    {
        _angleX = 30;
        _angleY = 30;

        _howEdamameRandRange = new int[7];
        _kind = new KindEdamame();
        _remainingEdamameMgr = _remainingEdamameMgrObj.GetComponent<RemainingEdamameMgr>();

        for (int num = 0; num < 30; ++num)
        {
            for (int i = 0; i < _howEdamameShow.Length; ++i)
            {
                if (i == 0)
                {
                    _howEdamameRandRange[0] = _howEdamameShow[0];
                    continue;
                }

                _howEdamameRandRange[i] = _howEdamameRandRange[i - 1] + _howEdamameShow[i];
            }

            int randEdamame = Random.Range(1, _howEdamameRandRange[6] + 1);
            for (int i = 0; i < _howEdamameRandRange.Length; ++i)
            {
                if (i == 0)
                {
                    if (randEdamame <= _howEdamameRandRange[0])
                    {
                        _kind = (KindEdamame)i;
                        break;
                    }

                    continue;
                }

                if (randEdamame >= _howEdamameRandRange[i - 1] && randEdamame <= _howEdamameRandRange[i])
                {
                    _kind = (KindEdamame)i;
                    break;
                }
            }

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

            // ���W�ݒ�
            float x = Random.Range(-EDAMAME_RANGE_W, EDAMAME_RANGE_W);
            float y = Random.Range(1, 3);
            float z = Random.Range(-EDAMAME_RANGE_H, EDAMAME_RANGE_H);

            _currentEdamame = Instantiate(_edamamePrefab, new Vector3(x, y, z + 3), Quaternion.identity);// �}������
            _currentEdamame.GetComponent<Collider>().enabled = true;
            _currentEdamame.GetComponent<Rigidbody>().useGravity = true;

        }
            CreateNewEdamame();
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

            CreateNewEdamame();
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

    public void CreateNewEdamame()
    {
        for (int i = 0; i < _howEdamameShow.Length; ++i)
        {
            if (i == 0)
            {
                _howEdamameRandRange[0] = _howEdamameShow[0];
                continue;
            }

            _howEdamameRandRange[i] = _howEdamameRandRange[i - 1] + _howEdamameShow[i];
        }

        int randEdamame = Random.Range(1, _howEdamameRandRange[6] + 1);
        for (int i = 0; i < _howEdamameRandRange.Length; ++i)
        {
            if (i == 0)
            {
                if (randEdamame <= _howEdamameRandRange[0])
                {
                    _kind = (KindEdamame)i;
                    break;
                }

                continue;
            }

            if (randEdamame >= _howEdamameRandRange[i - 1] && randEdamame <= _howEdamameRandRange[i])
            {
                _kind = (KindEdamame)i;
                break;
            }
        }

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
