using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Basket : MonoBehaviour
{
    // �}�����L���b�`������
    private bool _hasCaughtArrowEdamame;

    // �ǂ̎}����
    private KindOdEdamame _kind;

    // ���̓��̌��ʎ���
    [SerializeField] private float _maxTimeOfBigBasket;

    // ���̎}�����L���b�`�����Ƃ��ɂǂꂾ�����ʂ������Ă��邩
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
        // ���̎}����������Ƃ�
        if (_hasCaughtArrowEdamame)
        {
            // ���ʂ��؂ꂽ�Ƃ�
            if (_timerOfBigBasket > _maxTimeOfBigBasket)
            {
                _hasCaughtArrowEdamame = false;
                gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            }

            _timerOfBigBasket += Time.deltaTime;
        }
    }

    /// <summary>
    /// �}�����L���b�`�����Ƃ�
    /// </summary>
    /// <param name="kind"> �}���̎�� </param>
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
