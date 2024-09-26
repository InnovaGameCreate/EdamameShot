using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class A2 : MonoBehaviour
{
    public bool _isFever = false;   // �t�B�[�o�[��Ԃ������t���O
    public AudioClip feverAudio;   // isFever��true�̎��̃I�[�f�B�I
    public AudioClip normalAudio;  // isFever��false�̎��̃I�[�f�B�I
    private AudioSource audioSource;
    private Fever _fever;

    void Start()
    {
        // AudioSource�R���|�[�l���g���擾
        audioSource = GetComponent<AudioSource>();
    }

    // �������Đ����郁�\�b�h


    void Update()
    {
        if (_fever.GetIsFever())
        {
            // �t�B�[�o�[���̉������Đ�
            if (feverAudio != null && audioSource != null)
            {
                audioSource.PlayOneShot(feverAudio);
            }
        }

        else
        {
            // �ʏ펞�̉������Đ�
            if (normalAudio != null && audioSource != null)
            {
                audioSource.PlayOneShot(normalAudio);
            }
        }

    }
}