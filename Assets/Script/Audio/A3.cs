using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A3 : MonoBehaviour
{
    public AudioSource audioSource; // アタッチするAudioSourceコンポーネント
    public AudioClip audioClip1; // 最初に再生するオーディオクリップ
    public AudioClip audioClip2; // 次に再生するオーディオクリップ

    void Start()
    {
        StartCoroutine(PlayAudioSequence());
    }

    IEnumerator PlayAudioSequence()
    {
        audioSource.clip = audioClip1;
        audioSource.Play();

        // 3秒待つ
        yield return new WaitForSeconds(3f);

        // オーディオクリップ2に切り替え
        audioSource.clip = audioClip2;
        audioSource.Play();
    }
}