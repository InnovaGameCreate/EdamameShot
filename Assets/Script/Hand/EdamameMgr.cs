using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdamameMgr : MonoBehaviour
{
    // 角度の範囲
    public const float ANGLE_X_MIN = 30;
    public const float ANGLE_X_MAX = 150;
    public const float ANGLE_Y_MIN = 10;
    public const float ANGLE_Y_MAX = 80;

    // 角度
    private float _angleX;
    private float _angleY;

    // どれだけ一回で角度を動かすか
    [SerializeField] private float _speedAngle;

    // 枝豆Prefab
    [SerializeField] private GameObject _edamamePrefab;

    // 保持している枝豆
    private GameObject _currentEdamame;

    // Start is called before the first frame update
    void Start()
    {
        _angleX = 30;
        _angleY = 30;
        _currentEdamame = Instantiate(_edamamePrefab);// 枝豆生成
    }

    // Update is called once per frame
    void Update()
    {
        if (isShoot())
        {
            Edamame edamame = _currentEdamame.GetComponent<Edamame>();
            edamame.ShootEdamame(_angleX, _angleY);// 枝豆発射

            _currentEdamame = Instantiate(_edamamePrefab);// 新しい枝豆生成
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


        Debug.Log("angleX: " + _angleX);
        Debug.Log("angleY: " + _angleY);
    }
}
