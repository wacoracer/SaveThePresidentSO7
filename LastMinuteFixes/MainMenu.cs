using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject hideToShowSettings;
    public GameObject endlessButton;
    public GameObject SettingsMenu;
    public Slider soundEffects;
    public Slider siren;
    public Slider music;

    public static bool gameIsPaused = false;
    public GameObject pauseGameUI;
    bool settingsMenuActive = false;
    public GameObject background;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused || gameIsPaused && settingsMenuActive)
            {
                ResumeMidGame();
            }

            else if(settingsMenuActive)
            {
                ResumeMainMenu();
            }

            else if(SceneManager.GetActiveScene().name == "Game")
            {
                Pause();
            }
        }
    }

    public void ResumeMidGame()
    {
        pauseGameUI.SetActive(false);
        settingsMenuActive = false;
        SettingsMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void ResumeMainMenu()
    {
        pauseGameUI.SetActive(false);
        settingsMenuActive = false;
        SettingsMenu.SetActive(false);
        hideToShowSettings.SetActive(true);
        endlessButton.SetActive(true);
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseGameUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    
    public void MenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
        gameIsPaused = false;
        pauseGameUI.SetActive(false);
        background.SetActive(true);
        hideToShowSettings.SetActive(true);
        endlessButton.SetActive(true);

    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game Closed");

    }

    public void StartGame()
    {
        hideToShowSettings.SetActive(false);
        endlessButton.SetActive(false);
        GameObject.Find("Background").SetActive(false);
        EndlessButtonText.playingEndless = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SettingsButton()
    {
        settingsMenuActive = true;
        hideToShowSettings.SetActive(false);
        endlessButton.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    public void ExitSettingsMenu()
    {
        /*PlayerPrefs.SetFloat("SoundEffectsVolume", soundEffects.value);
        Debug.Log("Set PlayerPref for sound effects: " + PlayerPrefs.GetFloat("SoundEffectsVolume", 1f));
        PlayerPrefs.SetFloat("SirenVolume", siren.value);
        PlayerPrefs.SetFloat("MusicVolume", music.value);*/
        if(SceneManager.GetActiveScene().name == "Main Menu")
        {
            settingsMenuActive = false;
            hideToShowSettings.SetActive(true);
            endlessButton.SetActive(true);
            SettingsMenu.SetActive(false);
        }

        if(SceneManager.GetActiveScene().name == "Game")
        {
            settingsMenuActive = false;
            SettingsMenu.SetActive(false);
        }
        
    }

    public void EndlessButton()
    {
        if(GameObject.FindWithTag("DoIExist").GetComponent<EndlessPedestrianSpawner>().endlessUnlocked)
        {
            hideToShowSettings.SetActive(false);
            endlessButton.SetActive(false);
            GameObject.Find("Background").SetActive(false);
            EndlessButtonText.playingEndless = true;
            SceneManager.LoadScene("Starting cutscene endless");
        }

    }


        


}
