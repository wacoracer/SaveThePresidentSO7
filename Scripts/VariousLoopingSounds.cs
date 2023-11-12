using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariousLoopingSounds : MonoBehaviour
{
    public AudioSource siren;

    // Start is called before the first frame update
    void Start()
    {
        PlayLoopingSound();
    }

    void PlayLoopingSound()
    {
        siren.Play();
    }

    
}
