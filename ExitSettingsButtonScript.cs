using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class ExitSettingsButtonScript : MonoBehaviour
{
    private float clickTime;            // time of last click
    private int clickCount=0;         // current click count
    public bool onClick = true;            // is click allowed on button?
    public bool onDoubleClick = false;    // is double-click allowed on button?
    public GameObject hideToShowSettings;
    public GameObject SettingsMenu;
    
    void Awake()
    {
        if(SceneManager.GetActiveScene().name == "Game")
        {
            hideToShowSettings = new GameObject("Useless");
            SettingsMenu = GameObject.FindWithTag("Settings");
        }
    }
    
   
    public void OnPointerClick(PointerEventData data)
    {        
        // get interval between this click and the previous one (check for double click)
        float interval = data.clickTime - clickTime;
 
        // if this is double click, change click count
        if (interval < 0.5 && interval > 0 && clickCount != 2)
        {
            clickCount = 2;
        }
        else
        {
            clickCount = 1;
        }

        // reset click time
        clickTime = data.clickTime;
           
        // single click
        if (onClick && clickCount == 1)
        {
            if(SceneManager.GetActiveScene().name == "Main Menu")
            {
                hideToShowSettings.SetActive(true);
                SettingsMenu.SetActive(false);
            }

            else
            {
                SettingsMenu.SetActive(false);
            }
        }
    }

}
