using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundVolume : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("SoundVolume", Mathf.Log10(sliderValue) * 20); //Log10 since the audio uses a log, but the slider is linear by default. Times by 20 to fit the slider better

    }
}
