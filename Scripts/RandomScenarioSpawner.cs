using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RandomScenarioSpawner : MonoBehaviour
{
    public GameObject[] pedestrians;
    public GameObject[] leftLights;
    public GameObject[] rightLights;
    public GameObject[] crossings;
    [SerializeField] static float distanceDownTheRoad = 100; //How far it is from the trigger to the pedestrian
    [SerializeField] static float pedestrianLeftFirst = 1; //How far the pedestrian is to the left or right of the middle of the road
    [SerializeField] static float pedestrianLeftSecond = 3;
    [SerializeField] static float pedestrianRightFirst = 6; 
    [SerializeField] static float pedestrianRightSecond = 8; 
    Vector3 pedestrianLeftOneOffset = new Vector3(pedestrianLeftFirst, 0.4f, distanceDownTheRoad);
    Vector3 pedestrianLeftTwoOffset = new Vector3(pedestrianLeftSecond, 0.4f, distanceDownTheRoad);
    Vector3 pedestrianRightOneOffset = new Vector3(pedestrianRightFirst, 0.4f, distanceDownTheRoad);
    Vector3 pedestrianRightTwoOffset = new Vector3(pedestrianRightSecond, 0.4f, distanceDownTheRoad);
    [SerializeField] static float trafficLightDistance = distanceDownTheRoad + 5;
    [SerializeField] static float trafficLightOffset = 6f;
    Vector3 trafficLightPlacementLeft = new Vector3(-trafficLightOffset, 2f, trafficLightDistance);
    Vector3 trafficLightPlacementRight = new Vector3(trafficLightOffset, 2f, trafficLightDistance);
    Vector3 crossingPlacementLeft = new Vector3(0, -1f, distanceDownTheRoad);
    Vector3 crossingPlacementRight = new Vector3(5.33f, -1f, distanceDownTheRoad);


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision with random spawner");
        if(other.tag == "Player")
        {
            
            Debug.Log("Spawned a random scenario");
            //Pedestrians
            Instantiate(pedestrians[Random.Range(0, pedestrians.Length -1)], transform.position + pedestrianLeftOneOffset, Quaternion.Euler(new Vector3(90,0,180)));
            Instantiate(pedestrians[Random.Range(0, pedestrians.Length -1)], transform.position + pedestrianLeftTwoOffset, Quaternion.Euler(new Vector3(90,0,180)));
            Instantiate(pedestrians[Random.Range(0, pedestrians.Length -1)], transform.position + pedestrianRightOneOffset, Quaternion.Euler(new Vector3(90,0,180)));
            Instantiate(pedestrians[Random.Range(0, pedestrians.Length -1)], transform.position + pedestrianRightTwoOffset, Quaternion.Euler(new Vector3(90,0,180)));

            //Traffic lights
            Instantiate(leftLights[Random.Range(0, leftLights.Length -1)], transform.position + trafficLightPlacementLeft, Quaternion.Euler(new Vector3(90,0,180)));
            Instantiate(rightLights[Random.Range(0, rightLights.Length -1)], transform.position + trafficLightPlacementRight, Quaternion.Euler(new Vector3(90,0,180)));

            //Crossings
            Instantiate(crossings[Random.Range(0, crossings.Length -1)], transform.position + crossingPlacementLeft, transform.rotation);
            Instantiate(crossings[Random.Range(0, crossings.Length -1)], transform.position + crossingPlacementRight, transform.rotation);

            //Remove trigger
            Destroy(gameObject);
        }
    }
}
