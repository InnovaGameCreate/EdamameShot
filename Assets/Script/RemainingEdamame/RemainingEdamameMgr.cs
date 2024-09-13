using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainingEdamameMgr : MonoBehaviour
{
    // �c�e��\������摜
    private GameObject[] _remainingEdamameImgMasksObj;

    // �c�e
    private int _numRemainingEdamame;

    // �c�e�̏��
    [SerializeField] private int _maxRemainingEdamame;

    // �c�e�������鎞��
    [SerializeField] private float _intervalRemainingTime;

    // �o�߂�������
    private float _time;

    // �}�X�N�𓮂����͈�
    [SerializeField] private float _maxMaskBottom;
    [SerializeField] private float _minMaskBottom;

    // �}�X�N�̃X�s�[�h
    private float _speedChangeBottom;

    // Start is called before the first frame update
    void Start()
    {
        _remainingEdamameImgMasksObj = new GameObject[_maxRemainingEdamame];
        _numRemainingEdamame = _maxRemainingEdamame;
        _speedChangeBottom = _maxMaskBottom - _minMaskBottom;
        _time = 0;

        // �}�X�N���擾���C�ʒu��������
        for (int i = 0; i < _maxRemainingEdamame; ++i)
        {
            _remainingEdamameImgMasksObj[i] = GameObject.Find($"Mask{3 - i}");
            _remainingEdamameImgMasksObj[i].GetComponent<RectMask2D>().padding = new Vector3(0, _minMaskBottom, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_numRemainingEdamame < _maxRemainingEdamame)
        {
            _time += Time.deltaTime;

            DrawNewRemainingEdamame();
            if (_time >= _intervalRemainingTime)// 1�b�o������1��
            {
                _numRemainingEdamame++;
                _time = 0;
            }
        }
    }

    /// <summary>
    /// ��ԍŐV�̎}���̎c�e�̉摜�ɂ��Ă̏���
    /// </summary>
    private void DrawNewRemainingEdamame()
    {
        _remainingEdamameImgMasksObj[2 - _numRemainingEdamame].GetComponent<RectMask2D>().padding =
            new Vector4(0, _maxMaskBottom - _speedChangeBottom * _time, 0, 0);
    }

    /// <summary>
    /// �c��̎}�������炷
    /// </summary>
    /// <returns> true: ����, false: ���s(�c�e������Ȃ�) </returns>
    public bool DeleteRemainingEdamame()
    {
        // �c�e����0�̂Ƃ����˂��Ȃ�
        if (_numRemainingEdamame < 1)
        {
            return false;
        }

        _numRemainingEdamame--;// �c�e�����炷

        // �c�e�̉摜���B��
        for (int i = 2 - _numRemainingEdamame; i >= 0; --i)
        {
            _remainingEdamameImgMasksObj[i].GetComponent<RectMask2D>().padding = new Vector4(0, _maxMaskBottom, 0, 0);
        }
        _time = 0;

        return true;
    }
}
