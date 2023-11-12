using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainSounds : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        PlayLoopingSound();
    }

    void PlayLoopingSound()
    {
        audioSource.Play();
    }
}
