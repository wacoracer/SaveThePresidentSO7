using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class EndingSceneTrackerDisplay : MonoBehaviour
{
    
    public Text output;
    [SerializeField] float timeBeforeStart = 4;
    [SerializeField] float timeBetweenCounts = 1;
    [SerializeField] float timeFromTextToSwitch = 3;
    float triggeredAnIfStatement;

    float adultMen = CollisionAndTrigger.deadAdultMen;
    float adultWomen = CollisionAndTrigger.deadAdultWomen;
    float oldMen = CollisionAndTrigger.deadOldMen;
    float oldWomen = CollisionAndTrigger.deadOldWomen;
    float youngBoys = CollisionAndTrigger.deadYoungBoys;
    float youngGirls = CollisionAndTrigger.deadYoungGirls;
    string whoDidYouKill = "\n\n\n";

    private GameObject mainMenu;

    
    
    public void Start()
    {
            mainMenu = GameObject.FindWithTag("ThisIsTheOneBBG");
            if(GameObject.FindWithTag("DoIExist").GetComponent<EndlessPedestrianSpawner>().endlessStatusCarrier && adultMen + adultWomen + oldMen + oldWomen + youngBoys + youngGirls == 0)
            {
                StartCoroutine(pacifistInEndless());
            }
            
            else
            {
                StartCoroutine(EndingScene());
            }
    }

    IEnumerator EndingScene()
    {
        yield return new WaitForSeconds(timeBeforeStart);

        AdultMen();
        yield return new WaitForSeconds(timeBetweenCounts * triggeredAnIfStatement);
        triggeredAnIfStatement = 0;

        AdultWomen();
        yield return new WaitForSeconds(timeBetweenCounts * triggeredAnIfStatement);
        triggeredAnIfStatement = 0;

        OldMen();
        yield return new WaitForSeconds(timeBetweenCounts * triggeredAnIfStatement);
        triggeredAnIfStatement = 0;

        OldWomen();
        yield return new WaitForSeconds(timeBetweenCounts * triggeredAnIfStatement);
        triggeredAnIfStatement = 0;
        
        YoungBoys();
        yield return new WaitForSeconds(timeBetweenCounts * triggeredAnIfStatement);
        triggeredAnIfStatement = 0;

        YoungGirls();
        yield return new WaitForSeconds(timeBetweenCounts * triggeredAnIfStatement);
        triggeredAnIfStatement = 0;
        
        whoDidYouKill = whoDidYouKill + "\nYou will have to live with the guilt for the rest of your life";
        output.text = whoDidYouKill;

        IfEndlessJustUnlocked();
        yield return new WaitForSeconds(timeFromTextToSwitch * triggeredAnIfStatement);
        triggeredAnIfStatement = 0;

        yield return new WaitForSeconds(timeFromTextToSwitch);
        mainMenu.GetComponent<MainMenu>().MenuButton();
    }

    IEnumerator pacifistInEndless()
    {
        yield return new WaitForSeconds(timeBeforeStart);
        whoDidYouKill = whoDidYouKill + "Wait, you didn't kill anyone?";
        output.text = whoDidYouKill;
        yield return new WaitForSeconds(timeFromTextToSwitch);
        whoDidYouKill = whoDidYouKill + "\nI think you missed the point of endless mode...";
        output.text = whoDidYouKill;
        yield return new WaitForSeconds(timeFromTextToSwitch + 2);
        mainMenu.GetComponent<MainMenu>().MenuButton();
    }

    void IfEndlessJustUnlocked()
    {
        if(GameObject.FindWithTag("DoIExist").GetComponent<EndlessPedestrianSpawner>().endlessUnlocked && GameObject.FindWithTag("DoIExist").GetComponent<EndlessPedestrianSpawner>().firstTimeUnlockingEndless)
        {
            Debug.Log("Informing the player that they unlocked endless mode");
            whoDidYouKill = whoDidYouKill + "\n\nYou have unlocked endless mode you murderer";
            output.text = whoDidYouKill;
            GameObject.FindWithTag("DoIExist").GetComponent<EndlessPedestrianSpawner>().firstTimeUnlockingEndless = false;
            triggeredAnIfStatement++;
        }
    }

    void AdultMen()
    {
            if(adultMen == 1)
            {
                whoDidYouKill = whoDidYouKill + "- " + adultMen + " adult man \n";
                triggeredAnIfStatement++;
            }
            else if(adultMen > 1)
            {
                whoDidYouKill = whoDidYouKill + "- " +  adultMen + " adult men \n";
                triggeredAnIfStatement++;
            }
            output.text = whoDidYouKill;
    }

    void AdultWomen()
    {
            if(adultWomen == 1)
            {
                whoDidYouKill = whoDidYouKill + "- " +  adultWomen + " adult woman \n";
                triggeredAnIfStatement++;
            }
            else if(adultWomen > 1)
            {
                whoDidYouKill = whoDidYouKill + "- " +  adultWomen + " adult women \n";
                triggeredAnIfStatement++;
            }
            output.text = whoDidYouKill;
    }

    void OldMen()
    {
            if(oldMen == 1)
            {
                whoDidYouKill = whoDidYouKill + "- " +  oldMen + " old man \n";
                triggeredAnIfStatement++;
            }
            else if(oldMen > 1)
            {
                whoDidYouKill = whoDidYouKill + "- " +  oldMen + " old men \n";
                triggeredAnIfStatement++;
            }
            output.text = whoDidYouKill;
    }

    void OldWomen()
    {
            if(oldWomen == 1)
            {
                whoDidYouKill = whoDidYouKill + "- " +  oldWomen + " old woman \n";
                triggeredAnIfStatement++;
            }
            else if(oldWomen > 1)
            {
                whoDidYouKill = whoDidYouKill + "- " +  oldWomen + " old women \n";
                triggeredAnIfStatement++;
            }
            output.text = whoDidYouKill;
    }

    void YoungBoys()
    {
            if(youngBoys == 1)
            {
                whoDidYouKill = whoDidYouKill + "- " +  youngBoys + " young boy \n";
                triggeredAnIfStatement++;
            }
            else if(youngBoys > 1)
            {
                whoDidYouKill = whoDidYouKill + "- " +  youngBoys + " young boys \n";
                triggeredAnIfStatement++;
            }
            output.text = whoDidYouKill;
    }

    void YoungGirls()
    {
            if(youngGirls == 1)
            {
                whoDidYouKill = whoDidYouKill + "- " +  youngGirls + " young girl \n";
                triggeredAnIfStatement++;
            }
            else if(youngGirls > 1)
            {
                whoDidYouKill = whoDidYouKill + "- " +  youngGirls + " young girls \n";
                triggeredAnIfStatement++;
            }
            output.text = whoDidYouKill;
    }
}
