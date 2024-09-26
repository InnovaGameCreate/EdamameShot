using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sample : MonoBehaviour
{
    public AudioClip soundClip;  
    private AudioSource audioSource;

    void Start()
    {
        // AudioSource‚ðŽæ“¾
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaySound();
        }
    }

    void PlaySound()
    {
             if (soundClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(soundClip);
        }
        else
        {
            Debug.LogWarning("A");
        }
    }
}