using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianMovement : MonoBehaviour
{
    [SerializeField] float pedestrianSpeed = 5; //How fast does the pedestrian walk
    [SerializeField] float pedestrianStopPosition = 8; //what x-value (relative to x=0) should the pedestrian stop walking at
    [SerializeField] float oldPersonDebuff = 0.8f; //How many % speed should old people walk compared to standard
    [SerializeField] float childDebuff = 0.9f; //How many % speed should children walk compared to standard
    private GameObject player;
    
    
    
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log(gameObject.tag);
        player = GameObject.FindWithTag("Player");
        if(player == GameObject.FindWithTag("Player"))
        {
            Debug.Log("Player found");
        }

        else
        {
            Debug.LogWarning("Player not found");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.z > transform.position.z - 40)
        {
            if(transform.position.x < -pedestrianStopPosition)
            {
                Debug.Log("Pedestrian crossed the road");
            }
            else if(gameObject.tag == "YoungBoy" || gameObject.tag == "YoungGirl") //Speed for child
            {
                transform.position = transform.position + Vector3.left * pedestrianSpeed * childDebuff * Time.deltaTime;
            }

            else if(gameObject.tag == "OldMan" || gameObject.tag == "OldWoman") //Speed for old person
            {
                transform.position = transform.position + Vector3.left * pedestrianSpeed * oldPersonDebuff * Time.deltaTime;
            }

            else //Default walk speed
            {
                transform.position = transform.position + Vector3.left * pedestrianSpeed * Time.deltaTime;
            }
        }
    }

    
    

    /*
    Pseudo code: 
    Pedestrian has to walk at a speed set by a variable we can change in unity (done). Maybe the movement speed of the pedestrian should vary based on the person
    They have to walk until their position reaches a specific x-value and then they have to stop (done)
    They have to act as a trigger for the player. If the trigger is hit they despawn and their tag (for example "small girl") must be added to a counter
    This counter keeps track of all the pedestrians you kill and is shown at the final screen
    Once the player has passed them the pedestrian must despawn (probably done with a trigger on the other side of the scenario)
    */
}
