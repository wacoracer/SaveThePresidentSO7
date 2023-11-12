using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicScript : MonoBehaviour
{
    public AudioClip menuMusic;
    public AudioClip gameMusic;
    AudioSource musicSource;
    [SerializeField] bool playingGameMusic = false;
    
    
    void Awake()
    {
        musicSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if(playingGameMusic == false && SceneManager.GetActiveScene().buildIndex == 2)
        {
            musicSource.clip = gameMusic;
            musicSource.Play();
            playingGameMusic = true;
        }

        if(playingGameMusic == true && SceneManager.GetActiveScene().buildIndex > 2 || playingGameMusic == true && SceneManager.GetActiveScene().buildIndex < 2)
        {
            musicSource.clip = menuMusic;
            musicSource.Play();
            playingGameMusic = false;
        }
    }


}
