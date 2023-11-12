using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioDespawnScript : MonoBehaviour
{
    private GameObject player;
    float distanceBetweenPlayerAndObject; //to measure if player is past the object
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distanceBetweenPlayerAndObject = transform.position.z - player.transform.position.z; //negative value means player has passed the object
        if(distanceBetweenPlayerAndObject < -5)
        {
            Destroy(gameObject);
            Debug.Log("Despawned " + gameObject);
        }
    }
}
