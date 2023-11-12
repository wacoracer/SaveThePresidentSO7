using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSceneSurvivor : MonoBehaviour
{
    public GameObject SceneSurvivor;
    public GameObject UIStuff;
    

    void Awake()
    {
        
        if(GameObject.FindWithTag("DoIExist"))
        {
            Destroy(gameObject);
        }

        else
        {
            Instantiate(SceneSurvivor, transform.position, transform.rotation);
            Instantiate(UIStuff, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
