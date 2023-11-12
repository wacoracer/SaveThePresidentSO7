using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject Road;
    private GameObject player;
    public static float roadRepeat = 0;
    [SerializeField] float spawningLocation = 54;

    Vector3 roadSpawnLocation = new Vector3(0, 0, 0);

    
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        roadRepeat = 0;
        Debug.Log("Connected to player");
    }

    void Update()
    {
        
        Debug.Log("Found player position");
    
        if(player.transform.position.z > spawningLocation + 108 * roadRepeat && ERSpawner.ERSpawned == false)
        {
            roadSpawnLocation = new Vector3(0, 0, spawningLocation + 108 * roadRepeat + 216);
            Instantiate(Road, transform.position + roadSpawnLocation, transform.rotation);
            roadRepeat++;
            Debug.Log("Spawned a new road");
        }
    }
}
