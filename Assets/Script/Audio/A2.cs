using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class A2 : MonoBehaviour
{
    public bool _isFever = false;   // フィーバー状態を示すフラグ
    public AudioClip feverAudio;   // isFeverがtrueの時のオーディオ
    public AudioClip normalAudio;  // isFeverがfalseの時のオーディオ
    private AudioSource audioSource;
    private Fever _fever;

    void Start()
    {
        // AudioSourceコンポーネントを取得
        audioSource = GetComponent<AudioSource>();
    }

    // 音声を再生するメソッド


    void Update()
    {
        if (_fever.GetIsFever())
        {
            // フィーバー時の音声を再生
            if (feverAudio != null && audioSource != null)
            {
                audioSource.PlayOneShot(feverAudio);
            }
        }

        else
        {
            // 通常時の音声を再生
            if (normalAudio != null && audioSource != null)
            {
                audioSource.PlayOneShot(normalAudio);
            }
        }

    }
}