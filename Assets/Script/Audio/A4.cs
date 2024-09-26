using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A4 : MonoBehaviour
{
    public AudioSource audioSource; // アタッチするAudioSourceコンポーネント
    public AudioClip audioClip1;    // 左右矢印キーで再生するオーディオクリップ
    public AudioClip audioClip2;    // 上下矢印キーで再生するオーディオクリップ

    private bool isPlayingClip1 = false;
    private bool isPlayingClip2 = false;

    void Update()
    {
        bool leftOrRightArrowPressed = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow);
        bool upOrDownArrowPressed = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow);

        if (leftOrRightArrowPressed)
        {
            if (!isPlayingClip1)
            {
                PlayAudioClip1();
            }
        }
        else if (upOrDownArrowPressed)
        {
            if (!isPlayingClip2)
            {
                PlayAudioClip2();
            }
        }
        else
        {
            StopAudio();
        }
    }

    void PlayAudioClip1()
    {
        audioSource.clip = audioClip1;
        audioSource.loop = true;
        audioSource.Play();
        isPlayingClip1 = true;
        isPlayingClip2 = false;
    }

    void PlayAudioClip2()
    {
        audioSource.clip = audioClip2;
        audioSource.loop = true;
        audioSource.Play();
        isPlayingClip2 = true;
        isPlayingClip1 = false;
    }

    void StopAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
            isPlayingClip1 = false;
            isPlayingClip2 = false;
        }
    }
}