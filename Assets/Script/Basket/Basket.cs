using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Basket : MonoBehaviour
{
    // 枝豆をキャッチしたか
    private bool _hasCaughtArrowEdamame;

    // どの枝豆か
    private KindOdEdamame _kind;

    // 矢印の豆の効果時間
    [SerializeField] private float _maxTimeOfBigBasket;

    // 矢印の枝豆をキャッチしたときにどれだけ効果が続いているか
    private float _timerOfBigBasket;

    // Start is called before the first frame update
    void Start()
    {
        _hasCaughtArrowEdamame = false;

        _timerOfBigBasket = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // 矢印の枝豆を取ったとき
        if (_hasCaughtArrowEdamame)
        {
            // 効果が切れたとき
            if (_timerOfBigBasket > _maxTimeOfBigBasket)
            {
                _hasCaughtArrowEdamame = false;
                gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            }

            _timerOfBigBasket += Time.deltaTime;
        }
    }

    /// <summary>
    /// 枝豆をキャッチしたとき
    /// </summary>
    /// <param name="kind"> 枝豆の種類 </param>
    public void CatchEdamame(KindOdEdamame kind)
    {
        _kind = kind;
        switch (_kind)
        {
            case KindOdEdamame.NormalEdamame:
                break;

            case KindOdEdamame.ArrowEdamame:
                _hasCaughtArrowEdamame = true;
                gameObject.transform.localScale = new Vector3(1.5f, 0.8f, 0.8f);
                break;

            case KindOdEdamame.ClockEdamame:
                break;

            case KindOdEdamame.RopeEdamame:
                break;

            case KindOdEdamame.BlackEdamame:
                break;

            case KindOdEdamame.RainbowEdamame:
                break;

            case KindOdEdamame.GoldenEdamame:
                break;
        }
    }
}
