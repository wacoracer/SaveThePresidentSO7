using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Timer : MonoBehaviour
{
    public float gameTime = 2000;
    [SerializeField] float timer = 0;
    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameTimer());
    }

    IEnumerator GameTimer()
    {
        while(timer < gameTime)
        {
            timerText.text = Convert.ToString(gameTime - timer);
            yield return new WaitForSeconds(1);
            timer++;
        }
        
        if(timer >= gameTime)
        {
            if(GameObject.FindWithTag("DoIExist").GetComponent<EndlessPedestrianSpawner>().endlessStatusCarrier)
            {
                SceneManager.LoadScene("Endless over");
            }

            else
            {
                Debug.Log("Game over");
                SceneManager.LoadScene("Time ended cutscene");
            }
            
        }        
    }
}
