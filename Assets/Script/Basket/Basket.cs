using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Basket : MonoBehaviour
{
    // �X�R�A
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

    // �t�B�[�o�[
    [SerializeField] private GameObject _feverObj;
    private Fever _fever;

    // �����̑��x
    [SerializeField] float _speed;
    [SerializeField] private float _maxX;

    float _time;

    // Start is called before the first frame update
    void Start()
    {
        _time = 0;

        _hasCaughtArrowEdamame = false;
        _hasCaughtRopeEdamame = false;

        _timerBigBasket = 0;
        _timerFence = 0;

        _ropeEdamameFences = new List<GameObject>();

        _score = _scoreObj.GetComponent<Score>();

        _fever = _feverObj.GetComponent<Fever>();
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
        _time += Time.deltaTime;

        // ������
        float x = transform.position.x;
        if (Mathf.Abs(_speed * _time) >= _maxX)
        {
            _speed *= -1;
            _time = 0;
        }
        transform.Translate(new Vector3(_speed * Time.deltaTime, 0, 0));

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
                // �X�e�[�W�����𔚔�
                _score.AddScore(_blackEdamameScore);
                break;

            case KindEdamame.RainbowEdamame:
                _score.AddScore(_rainbowEdamameScore);

                _feverObj.GetComponent<Fever>().AddFeverGauge();
                break;

            case KindEdamame.GoldenEdamame:
                _score.AddScore(_goldenEdamameScore);
                break;
        }
    }

    private void FixedUpdate()
    {
        if (_fever.GetIsFever())
        {
            GameObject[] alledamames = GameObject.FindGameObjectsWithTag("Edamame");
            List<GameObject> edamamesOnField = new List<GameObject>();
            for (int i = 0; i < alledamames.Length; ++i)
            {
                if (alledamames[i].GetComponent<Edamame>().GetIsActiveFever())
                {
                    edamamesOnField.Add(alledamames[i]);
                }
            }

            for (int i = 0; i < edamamesOnField.Count; ++i)
            {
                float x = edamamesOnField[i].transform.position.x;
                float y = edamamesOnField[i].transform.position.y;
                float z = edamamesOnField[i].transform.position.z;

                float basX = transform.position.x;
                float basY = transform.position.y;
                float basZ = transform.position.z;

                float deltaX = basX - x;
                float deltaY = basY - y;
                float deltaZ = basZ - z;

                edamamesOnField[i].GetComponent<Collider>().isTrigger = true;
                edamamesOnField[i].GetComponent<Rigidbody>().useGravity = false;
                edamamesOnField[i].GetComponent<Rigidbody>().AddForce(new Vector3(deltaX, deltaY, deltaZ) * 10);
            }
        }
    }
}
