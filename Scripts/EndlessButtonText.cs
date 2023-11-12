using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndlessButtonText : MonoBehaviour
{
    //Required for unlocking endless
    public GameObject endlessText;
    public GameObject lockIcon;
    public Button endlessButton;
    
    private bool endlessUnlockedButton = false;

    //When you decide to play endless
    public static bool playingEndless = false;

    //Tip on how to unlock endless
    public GameObject settings;
    public GameObject exit;
    public GameObject tipText;
    private Image image;

    Vector3 offsetVector = new Vector3(0, 75, 0);

    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("The endless button woke up :)");
        playingEndless = false;
        image = GetComponent<Image>();

        
        Debug.Log(endlessUnlockedButton);
        
        
    }

    public void Update()
    {
        endlessUnlockedButton = GameObject.FindWithTag("DoIExist").GetComponent<EndlessPedestrianSpawner>().endlessUnlocked;
        if(endlessUnlockedButton && SceneManager.GetActiveScene().buildIndex == 0)
        {
            lockIcon.SetActive(false);
            endlessText.SetActive(true);
            endlessButton.enabled = true;
        }
    }

    public void HoveringOverButton()
    {
        if(endlessUnlockedButton == false)
        {
            settings.transform.position = settings.transform.position - offsetVector;
            exit.transform.position = exit.transform.position - offsetVector;
            tipText.SetActive(true);
            image.color = new Color32(154, 154, 154, 255); //set color 9A9A9A
        }
    }

    public void NotHovering()
    {
        if(endlessUnlockedButton == false)
        {
            tipText.SetActive(false);
            settings.transform.position = settings.transform.position + offsetVector;
            exit.transform.position = exit.transform.position + offsetVector;
            image.color = new Color(255, 255, 255, 255); //set color FFFFFF
        }
    }
    
}
