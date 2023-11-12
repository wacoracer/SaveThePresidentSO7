using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputAndSliderMatcher : MonoBehaviour
{
    public Slider mySlider;
    private float currentSliderValue;
    public GameObject myField;
    private TMP_InputField text;
    
    void Start()
    {
        /*if(mySlider == GameObject.Find("Sound Effects"))
        {
            mySlider.value = PlayerPrefs.GetFloat("SoundEffectsVolume", 1f);
            Debug.Log(gameObject + " PlayerPref SoundEffectsVolume used");
        }
        
        else if(mySlider == GameObject.Find("Siren"))
        {
            mySlider.value = PlayerPrefs.GetFloat("SirenVolume", 1f);
            Debug.Log(gameObject + " PlayerPref SirenVolume used");
        }

        else
        {
            mySlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
            Debug.Log(gameObject + " PlayerPref MusicVolume used");
        }
        text.text = Convert.ToString(Mathf.Round(Convert.ToSingle(mySlider.value) * 100));*/ //attempt at using saved player preferences for volume
        text = myField.GetComponent<TMP_InputField>();
    }
    
    public void ChangeSlider()
    {
        Debug.Log("it at least started the code");
        Debug.Log(mySlider.value);
        
        if(float.TryParse(text.text, out float number) == false)
        {
            text.text = "0";
        }

        currentSliderValue = Convert.ToSingle(mySlider.value.ToString());

        if(currentSliderValue != Convert.ToSingle(text) / 100 && float.TryParse(text.text, out float numb))
        {
                if(numb > 100)
                {
                    text.text = "100";
                    mySlider.value = 1;
                }

                else if(numb <= 0)
                {
                    text.text = "0";
                    mySlider.value = 0.0001f;
                }

                

                else
                {
                    mySlider.value = numb / 100;
                }
                
                Debug.Log(mySlider.value);
                Debug.Log("Slider changed to fit input field text");
        }
    }

    public void ChangeField()
    {
        if(Convert.ToSingle(text) != Convert.ToSingle(mySlider.value) * 100)
        {
            text.text = Convert.ToString(Mathf.Round(Convert.ToSingle(mySlider.value) * 100));
            if(text.text == "0.01")
            {
                text.text = "0";
            }

            
        }
    }

    
}
