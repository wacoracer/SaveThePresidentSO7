using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadDeletion : MonoBehaviour
{
    private GameObject player;
    private float playerPosition;
    [SerializeField] float deletingLocation = 5;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindWithTag("Player");   
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = player.transform.position.z;
        
        if(playerPosition > transform.position.z + 54 + deletingLocation)
        {
            Destroy(gameObject);
        }
    }
}
