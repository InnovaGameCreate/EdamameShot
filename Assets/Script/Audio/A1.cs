using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A1 : MonoBehaviour
{
    // �����̃��C���[�ɑΉ�����T�E���h�N���b�v��ݒ�
    [System.Serializable]
    public class LayerAudioPair
    {
        public int layer;          // ���C���[�ԍ�
        public AudioClip soundClip; // �Ή�����T�E���h�N���b�v
    }

    public List<LayerAudioPair> layerAudioPairs = new List<LayerAudioPair>();  // ���C���[�ƃT�E���h�̃y�A���X�g
    private AudioSource audioSource;

    void Start()
    {
        // AudioSource�R���|�[�l���g���擾
        audioSource = GetComponent<AudioSource>();

        // �X�t�B�A�R���C�_�[���擾���ăg���K�[�ɐݒ�
        SphereCollider sphereCollider = GetComponent<SphereCollider>();
        if (sphereCollider != null)
        {
            sphereCollider.isTrigger = true; // �g���K�[�Ƃ��Đݒ�
        }
    }

    // �g���K�[�ɐڐG�����ꍇ�ɌĂ΂��
    void OnTriggerEnter(Collider other)
    {
        // �ڐG�����I�u�W�F�N�g�̃��C���[���擾���ĉ������Đ�
        int triggerLayer = other.gameObject.layer;
        PlaySoundForLayer(triggerLayer);
    }

    // ���C���[�ɉ������������Đ����郁�\�b�h
    void PlaySoundForLayer(int layer)
    {
        // ���C���[�ɑΉ����鉹����T��
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

        Debug.LogWarning("�Ή����郌�C���[�܂��̓T�E���h�N���b�v��������܂���");
    }
}