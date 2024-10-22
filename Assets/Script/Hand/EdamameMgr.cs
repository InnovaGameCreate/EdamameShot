using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EdamameMgr : MonoBehaviour
{
    // 角度の範囲
    public const float ANGLE_X_MIN = 30;
    public const float ANGLE_X_MAX = 150;
    public const float ANGLE_Y_MIN = 30;
    public const float ANGLE_Y_MAX = 80;

    // 角度
    private float _angleX;
    private float _angleY;

    // どれだけ一回で角度を動かすか
    [SerializeField] private float _speedAngle;

    // 枝豆Prefab
    private GameObject _edamamePrefab;

    // 保持している枝豆
    private GameObject _currentEdamame;

    // 枝豆の種類
    KindEdamame _kind;

    // 全ての枝豆のPrefab
    [SerializeField] private GameObject NORMAL_EDAMAME_PREFAB;
    [SerializeField] private GameObject RAINBOW_EDAMAME_PREFAB;
    [SerializeField] private GameObject GOLDEN_EDAMAME_PREFAB;
    [SerializeField] private GameObject ROPE_EDAMAME_PREFAB;
    [SerializeField] private GameObject BLACK_EDAMAME_PREFAB;
    [SerializeField] private GameObject CLOCK_EDAMAME_PREFAB;
    [SerializeField] private GameObject ARROW_EDAMAME_PREFAB;

    // 枝豆の出る確率
    [SerializeField] private int[] _howEdamameShow;
    private int[] _howEdamameRandRange;

    // 残弾の管理するオブジェクト
    [SerializeField] private GameObject _remainingEdamameMgrObj;
    private RemainingEdamameMgr _remainingEdamameMgr;

    // 初期の枝豆を配置する範囲
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

            // 座標設定
            float x = Random.Range(-EDAMAME_RANGE_W, EDAMAME_RANGE_W);
            float y = Random.Range(1, 3);
            float z = Random.Range(-EDAMAME_RANGE_H, EDAMAME_RANGE_H);

            _currentEdamame = Instantiate(_edamamePrefab, new Vector3(x, y, z + 3), Quaternion.identity);// 枝豆生成
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
            edamame.ShootEdamame(_angleX, _angleY);// 枝豆発射

            CreateNewEdamame();
        }

        // 角度調整
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
        CheckAngleRange();  // 角度を制限
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

        _currentEdamame = Instantiate(_edamamePrefab);// 枝豆生成
    }

    /// <summary>
    /// 枝豆を発射するか
    /// </summary>
    /// <returns> true: スペースキーが押されたとき, false: スペースキーが押されていないとき</returns>
    bool isShoot()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    /// <summary>
    /// 設定された角度が有効かチェック
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
    /// 角度を取得(X)
    /// </summary>
    /// <returns> 角度(X) </returns>
    public float GetAngleX() { return _angleX; }
    /// <summary>
    /// 角度を取得(Y)
    /// </summary>
    /// <returns> 角度(X) </returns>
    public float GetAngleY() { return _angleY; }
}
