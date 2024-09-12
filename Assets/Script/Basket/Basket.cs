using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Basket : MonoBehaviour
{
    // Ž}“¤‚ðƒLƒƒƒbƒ`‚µ‚½‚©
    private bool _hasCaughtArrowEdamame;

    // ‚Ç‚ÌŽ}“¤‚©
    private KindOdEdamame _kind;

    // –îˆó‚Ì“¤‚ÌŒø‰ÊŽžŠÔ
    [SerializeField] private float _maxTimeOfBigBasket;

    // –îˆó‚ÌŽ}“¤‚ðƒLƒƒƒbƒ`‚µ‚½‚Æ‚«‚É‚Ç‚ê‚¾‚¯Œø‰Ê‚ª‘±‚¢‚Ä‚¢‚é‚©
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
        // –îˆó‚ÌŽ}“¤‚ðŽæ‚Á‚½‚Æ‚«
        if (_hasCaughtArrowEdamame)
        {
            // Œø‰Ê‚ªØ‚ê‚½‚Æ‚«
            if (_timerOfBigBasket > _maxTimeOfBigBasket)
            {
                _hasCaughtArrowEdamame = false;
                gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            }

            _timerOfBigBasket += Time.deltaTime;
        }
    }

    /// <summary>
    /// Ž}“¤‚ðƒLƒƒƒbƒ`‚µ‚½‚Æ‚«
    /// </summary>
    /// <param name="kind"> Ž}“¤‚ÌŽí—Þ </param>
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
