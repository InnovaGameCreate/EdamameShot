using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A3 : MonoBehaviour
{
    public AudioSource audioSource; // �A�^�b�`����AudioSource�R���|�[�l���g
    public AudioClip audioClip1; // �ŏ��ɍĐ�����I�[�f�B�I�N���b�v
    public AudioClip audioClip2; // ���ɍĐ�����I�[�f�B�I�N���b�v

    void Start()
    {
        StartCoroutine(PlayAudioSequence());
    }

    IEnumerator PlayAudioSequence()
    {
        audioSource.clip = audioClip1;
        audioSource.Play();

        // 3�b�҂�
        yield return new WaitForSeconds(3f);

        // �I�[�f�B�I�N���b�v2�ɐ؂�ւ�
        audioSource.clip = audioClip2;
        audioSource.Play();
    }
}