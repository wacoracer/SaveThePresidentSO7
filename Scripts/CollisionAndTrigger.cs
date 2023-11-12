using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollisionAndTrigger : MonoBehaviour
{
    public static float deadAdultMen;
    public static float deadAdultWomen;
    public static float deadOldMen;
    public static float deadOldWomen;
    public static float deadYoungBoys;
    public static float deadYoungGirls;
    public float totalDead;

    
    public Text killCountText;
    public GameObject killCount;

    void Awake()
    {
        deadAdultMen = 0;
        deadAdultWomen = 0;
        deadOldMen = 0;
        deadOldWomen = 0;
        deadYoungBoys = 0;
        deadYoungGirls = 0;
        killCountText = killCount.GetComponent<Text>();
        totalDead = 0;
        if(GameObject.FindWithTag("DoIExist").GetComponent<EndlessPedestrianSpawner>().endlessStatusCarrier)
        {
            killCount.SetActive(true);
        }

        else
        {
            killCount.SetActive(false);
        }
        killCountText.text = Convert.ToString(totalDead);
    }

        void OnTriggerEnter(Collider other)
        {
            Debug.Log("You hit a trigger");
            Debug.Log(other.tag);
            switch (other.tag)
            {
            case "AdultMan":
                Debug.Log("Trigger was an adult man");
                deadAdultMen ++;
                Debug.Log("You've killed: " + deadAdultMen + " adult men");
                totalDead++;
                killCountText.text = Convert.ToString(totalDead);
                if(GameObject.FindWithTag("DoIExist").GetComponent<EndlessPedestrianSpawner>().endlessStatusCarrier)
                    {
                        GameObject.Find("Timer").GetComponent<Timer>().gameTime += 1;
                    }
                break;

            case "AdultWoman":
                Debug.Log("Trigger was an adult woman");
                deadAdultWomen ++;
                Debug.Log("You've killed: " + deadAdultWomen + " adult women");
                totalDead++;
                killCountText.text = Convert.ToString(totalDead);
                if(GameObject.FindWithTag("DoIExist").GetComponent<EndlessPedestrianSpawner>().endlessStatusCarrier)
                    {
                        GameObject.Find("Timer").GetComponent<Timer>().gameTime += 1;
                    }
                break;

            case "OldMan":
                Debug.Log("Trigger was an old man");
                deadOldMen ++;
                Debug.Log("You've killed: " + deadOldMen + " old men");
                totalDead++;
                killCountText.text = Convert.ToString(totalDead);
                if(GameObject.FindWithTag("DoIExist").GetComponent<EndlessPedestrianSpawner>().endlessStatusCarrier)
                    {
                        GameObject.Find("Timer").GetComponent<Timer>().gameTime += -5;
                    }
                break;

            case "OldWoman":
                Debug.Log("Trigger was an old woman");
                deadOldWomen ++;
                Debug.Log("You've killed: " + deadOldWomen + " old women");
                totalDead++;
                killCountText.text = Convert.ToString(totalDead);
                if(GameObject.FindWithTag("DoIExist").GetComponent<EndlessPedestrianSpawner>().endlessStatusCarrier)
                    {
                        GameObject.Find("Timer").GetComponent<Timer>().gameTime += -5;
                    }
                break;

            case "YoungBoy":
                Debug.Log("Trigger was a young boy");
                deadYoungBoys ++;
                Debug.Log("You've killed: " + deadYoungBoys + " young boys");
                totalDead++;
                killCountText.text = Convert.ToString(totalDead);
                if(GameObject.FindWithTag("DoIExist").GetComponent<EndlessPedestrianSpawner>().endlessStatusCarrier)
                    {
                        GameObject.Find("Timer").GetComponent<Timer>().gameTime += 5;
                    }
                break;

            case "YoungGirl":
                Debug.Log("Trigger was a young girl");
                deadYoungGirls ++;
                Debug.Log("You've killed: " + deadYoungGirls + " young girls");
                totalDead++;
                killCountText.text = Convert.ToString(totalDead);
                if(GameObject.FindWithTag("DoIExist").GetComponent<EndlessPedestrianSpawner>().endlessStatusCarrier)
                    {
                        GameObject.Find("Timer").GetComponent<Timer>().gameTime += 5;
                    }
                break;
            }

            Debug.Log("Total dead: " + totalDead);
        }

        void OnTriggerExit(Collider other)
        {
            if(other.tag == "EndTrigger")
            {
                SceneManager.LoadScene("Ending cutscene");

            }
        }
}
