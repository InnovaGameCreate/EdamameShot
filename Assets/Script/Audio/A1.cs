using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A1 : MonoBehaviour
{
    // 複数のレイヤーに対応するサウンドクリップを設定
    [System.Serializable]
    public class LayerAudioPair
    {
        public int layer;          // レイヤー番号
        public AudioClip soundClip; // 対応するサウンドクリップ
    }

    public List<LayerAudioPair> layerAudioPairs = new List<LayerAudioPair>();  // レイヤーとサウンドのペアリスト
    private AudioSource audioSource;

    void Start()
    {
        // AudioSourceコンポーネントを取得
        audioSource = GetComponent<AudioSource>();

        // スフィアコライダーを取得してトリガーに設定
        SphereCollider sphereCollider = GetComponent<SphereCollider>();
        if (sphereCollider != null)
        {
            sphereCollider.isTrigger = true; // トリガーとして設定
        }
    }

    // トリガーに接触した場合に呼ばれる
    void OnTriggerEnter(Collider other)
    {
        // 接触したオブジェクトのレイヤーを取得して音声を再生
        int triggerLayer = other.gameObject.layer;
        PlaySoundForLayer(triggerLayer);
    }

    // レイヤーに応じた音声を再生するメソッド
    void PlaySoundForLayer(int layer)
    {
        // レイヤーに対応する音声を探す
        foreach (LayerAudioPair pair in layerAudioPairs)
        {
            if (pair.layer == layer)
            {
                if (audioSource != null && pair.soundClip != null)
                {
                    audioSource.PlayOneShot(pair.soundClip);
                }
                return;
            }
        }

        Debug.LogWarning("対応するレイヤーまたはサウンドクリップが見つかりません");
    }
}