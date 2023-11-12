using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    /*public static bool gameIsPaused = false;
    public GameObject pauseGameUI;
    private GameObject SettingsMenu;

    void Awake()
    {
        SettingsMenu = GameObject.FindWithTag("Settings");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused || pauseMenuActive)
            {
                Resume();
            }

            else if(SceneManager.GetActiveScene().name == "Game")
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseGameUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseGameUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void SettingsButton()
    {
        SettingsMenu.SetActive(true);
    }

        public void ExitSettingsMenu()
    {
        SettingsMenu.SetActive(false);
    }

    public void MenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game Closed");

    }*/
}
