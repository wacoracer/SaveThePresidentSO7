using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeOverScene : MonoBehaviour
{
    public Text output;
    [SerializeField] float timeBeforeStart = 4;
    [SerializeField] float timeBetweenCounts = 1;
    [SerializeField] float timeBetweenTextNoKills = 2;
    [SerializeField] float timeFromTextToSwitch = 4;
    float triggeredAnIfStatement;
    private GameObject mainMenu;

    float adultMen = CollisionAndTrigger.deadAdultMen;
    float adultWomen = CollisionAndTrigger.deadAdultWomen;
    float oldMen = CollisionAndTrigger.deadOldMen;
    float oldWomen = CollisionAndTrigger.deadOldWomen;
    float youngBoys = CollisionAndTrigger.deadYoungBoys;
    float youngGirls = CollisionAndTrigger.deadYoungGirls;
    float totalKills;
    string whoDidYouKill = "\n\n\n";
    
    public void Start()
    {
            mainMenu = GameObject.FindWithTag("ThisIsTheOneBBG");
            totalKills = adultMen + adultWomen + oldMen + oldWomen + youngBoys + youngGirls;
            if(totalKills > 0)
            {
                StartCoroutine(KillCounter());
            }

            else
            {
                StartCoroutine(MoralRun());
            }
    }

    IEnumerator MoralRun()
    {
        yield return new WaitForSeconds(timeBeforeStart);
        whoDidYouKill = whoDidYouKill + "\nYou decided not to kill anyone for the president's sake.";
        output.text = whoDidYouKill;
        
        yield return new WaitForSeconds(timeBetweenTextNoKills);
        whoDidYouKill = whoDidYouKill + "\n\nThe president may be dead, but your stable morals are worthy of respect";
        output.text = whoDidYouKill;

        yield return new WaitForSeconds(timeFromTextToSwitch);
        mainMenu.GetComponent<MainMenu>().MenuButton();
    }

    IEnumerator KillCounter()
    {
        yield return new WaitForSeconds(timeBeforeStart);
        whoDidYouKill = whoDidYouKill + "Before he died you killed:\n";
        output.text = whoDidYouKill;
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
        
        whoDidYouKill = whoDidYouKill + "\nYou will have to live with the guilt for the rest of your life";
        output.text = whoDidYouKill;

        IfEndlessJustUnlocked();
        yield return new WaitForSeconds(timeFromTextToSwitch * triggeredAnIfStatement);
        triggeredAnIfStatement = 0;

        yield return new WaitForSeconds(timeFromTextToSwitch);
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
