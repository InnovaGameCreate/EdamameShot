using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Basket : MonoBehaviour
{
    // �ǂ̎}����
    private KindEdamame _kind;

    // ���Prefab
    [SerializeField] private GameObject _ropeEdamame_fencePrefab;
    private List<GameObject> _ropeEdamameFences;

    // �^�C�}�[
    [SerializeField] private GameObject _timerObj;

    // ���}�����L���b�`������
    private bool _hasCaughtArrowEdamame;
    // �j�}�����L���b�`������
    private bool _hasCaughtRopeEdamame;

    // ���̓��̌��ʎ���
    [SerializeField] private float _maxTimeOfBigBasket;
    // ��̏o������
    [SerializeField] private float _maxTimeFence;

    // ���̎}�����L���b�`�����Ƃ��ɂǂꂾ�����ʂ������Ă��邩
    private float _timerBigBasket;
    // �򂪂ǂꂾ���o�Ă��邩
    private float _timerFence;

    // Start is called before the first frame update
    void Start()
    {
        _hasCaughtArrowEdamame = false;
        _hasCaughtRopeEdamame = false;

        _timerBigBasket = 0;
        _timerFence = 0;

        _ropeEdamameFences = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        // ���̎}����������Ƃ�
        if (_hasCaughtArrowEdamame)
        {
            // ���ʂ��؂ꂽ�Ƃ�
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
    /// �}�����L���b�`�����Ƃ�
    /// </summary>
    /// <param name="kind"> �}���̎�� </param>
    public void CatchEdamame(KindEdamame kind)
    {
        _kind = kind;
        switch (_kind)
        {
            case KindEdamame.NormalEdamame:
                break;

            case KindEdamame.ArrowEdamame:
                _hasCaughtArrowEdamame = true;
                gameObject.transform.localScale = new Vector3(1.5f, 0.8f, 0.8f);

                break;

            case KindEdamame.ClockEdamame:
                _timerObj.GetComponent<Timer>().AddTime(10);
                break;

            case KindEdamame.RopeEdamame:
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
                // �X�e�[�W�����𔚔�
                break;

            case KindEdamame.RainbowEdamame:
                break;

            case KindEdamame.GoldenEdamame:
                break;
        }
    }
}
