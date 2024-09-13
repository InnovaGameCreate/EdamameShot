using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Basket : MonoBehaviour
{
    // スコア
    [SerializeField] private GameObject _scoreObj;
    Score _score;

    [SerializeField] private int _normalEdamameScore;
    [SerializeField] private int _arrowEdamameScore;
    [SerializeField] private int _clockEdamameScore;
    [SerializeField] private int _ropeEdamameScore;
    [SerializeField] private int _ropeblackEdamameScore;
    [SerializeField] private int _blackEdamameScore;
    [SerializeField] private int _rainbowEdamameScore;
    [SerializeField] private int _goldenEdamameScore;

    // どの枝豆か
    private KindEdamame _kind;

    // 柵のPrefab
    [SerializeField] private GameObject _ropeEdamame_fencePrefab;
    private List<GameObject> _ropeEdamameFences;

    // タイマー
    [SerializeField] private GameObject _timerObj;

    // 矢印枝豆をキャッチしたか
    private bool _hasCaughtArrowEdamame;
    // 綱枝豆をキャッチしたか
    private bool _hasCaughtRopeEdamame;

    // 矢印の豆の効果時間
    [SerializeField] private float _maxTimeOfBigBasket;
    // 柵の出現時間
    [SerializeField] private float _maxTimeFence;

    // 矢印の枝豆をキャッチしたときにどれだけ効果が続いているか
    private float _timerBigBasket;
    // 柵がどれだけ出ているか
    private float _timerFence;

    // Start is called before the first frame update
    void Start()
    {
        _hasCaughtArrowEdamame = false;
        _hasCaughtRopeEdamame = false;

        _timerBigBasket = 0;
        _timerFence = 0;

        _ropeEdamameFences = new List<GameObject>();

        _score = _scoreObj.GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        // 矢印の枝豆を取ったとき
        if (_hasCaughtArrowEdamame)
        {
            // 効果が切れたとき
            if (_timerBigBasket > _maxTimeOfBigBasket)
            {
                _hasCaughtArrowEdamame = false;
                gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                _timerBigBasket = 0;
            }

            _timerBigBasket += Time.deltaTime;
        }

        if (_hasCaughtRopeEdamame)
        {
            if (_timerFence > _maxTimeFence)
            {
                _hasCaughtRopeEdamame = false;
                _timerFence = 0;

                for (int i = 0; i <  _ropeEdamameFences.Count; ++i)
                {
                    Destroy(_ropeEdamameFences[i]);
                }
                _ropeEdamameFences.Clear();
            }

            _timerFence += Time.deltaTime;
        }
    }

    /// <summary>
    /// 枝豆をキャッチしたとき
    /// </summary>
    /// <param name="kind"> 枝豆の種類 </param>
    public void CatchEdamame(KindEdamame kind)
    {
        _kind = kind;
        switch (_kind)
        {
            case KindEdamame.NormalEdamame:
                _score.AddScore(_normalEdamameScore);
                break;

            case KindEdamame.ArrowEdamame:
                _score.AddScore(_arrowEdamameScore);
                _hasCaughtArrowEdamame = true;
                gameObject.transform.localScale = new Vector3(1.5f, 0.8f, 0.8f);

                break;

            case KindEdamame.ClockEdamame:
                _score.AddScore(_clockEdamameScore);
                _timerObj.GetComponent<Timer>().AddTime(10);
                break;

            case KindEdamame.RopeEdamame:
                _score.AddScore(_ropeEdamameScore);
                if (!_hasCaughtRopeEdamame)
                {
                    for (int i = 0; i < 3; ++i)
                    {
                        _ropeEdamameFences.Add(Instantiate(_ropeEdamame_fencePrefab, new Vector3(-4.54f, 2.65f, 5.8f - 1.5f * i), Quaternion.identity));
                        _ropeEdamameFences.Add(Instantiate(_ropeEdamame_fencePrefab, new Vector3(4.54f, 2.65f, 5.8f - 1.5f * i), Quaternion.identity));
                    }
                }
                _hasCaughtRopeEdamame = true;
                break;

            case KindEdamame.BlackEdamame:
                // ステージ中央を爆発
                _score.AddScore(_blackEdamameScore);
                break;

            case KindEdamame.RainbowEdamame:
                _score.AddScore(_rainbowEdamameScore);
                break;

            case KindEdamame.GoldenEdamame:
                _score.AddScore(_goldenEdamameScore);
                break;
        }
    }
}
