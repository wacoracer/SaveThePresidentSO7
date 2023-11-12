using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Numerics;
using Vector3 = UnityEngine.Vector3;

public class EndlessPedestrianSpawner : MonoBehaviour
{
    public bool endlessStatusCarrier = false;
    public bool endlessUnlocked = false;
    public bool firstTimeUnlockingEndless = true;

    //For actually spawning scenarios
    public GameObject RandomScenario;
    private GameObject player;
    bool playerLocated = false;
    float scenarioRepeat = 0;
    [SerializeField] float distanceBetweenScenarios = 50;
    Vector3 scenarioSpawnLocation = new Vector3(0, 0, 0);

    [SerializeField] float killsToUnlockEndless = 20;


    

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            endlessStatusCarrier = EndlessButtonText.playingEndless;
        }

        else if(SceneManager.GetActiveScene().buildIndex == 2 && endlessStatusCarrier && playerLocated == false) //finds player
        {
            player = GameObject.FindWithTag("Player");
            scenarioRepeat = 0;
            playerLocated = true;
            Debug.Log("Found player");
        }

        else if(SceneManager.GetActiveScene().buildIndex == 2 && endlessStatusCarrier)
        {
            if(player.transform.position.z > distanceBetweenScenarios * scenarioRepeat)
            {
                scenarioSpawnLocation = new Vector3(0, 0.75f, distanceBetweenScenarios * scenarioRepeat + 50);
                Instantiate(RandomScenario, transform.position + scenarioSpawnLocation, transform.rotation);
                scenarioRepeat++;
                Debug.Log("Spawned scenario");
            }
        }

        else if(SceneManager.GetActiveScene().buildIndex < 2 || SceneManager.GetActiveScene().buildIndex > 2) //player is no longer found
        {
            playerLocated = false;
        }

        if(GameObject.FindWithTag("Player").GetComponent<CollisionAndTrigger>().totalDead > killsToUnlockEndless && endlessUnlocked == false)
            {
                endlessUnlocked = true;
                Debug.Log("Endless is now unlocked, you murderer");
            }
    }


}
