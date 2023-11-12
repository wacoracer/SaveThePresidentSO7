using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioCreator : MonoBehaviour
{
    //Pedestrians
    public GameObject pedestrianLeftOne;
    public GameObject pedestrianLeftTwo;
    public GameObject pedestrianRightOne;
    public GameObject pedestrianRightTwo;
    [SerializeField] static float distanceDownTheRoad = 25; //How far it is from the trigger to the pedestrian
    [SerializeField] static float pedestrianLeftFirst = 1; //How far the pedestrian is to the left or right of the middle of the road
    [SerializeField] static float pedestrianLeftSecond = 3;
    [SerializeField] static float pedestrianRightFirst = 6; 
    [SerializeField] static float pedestrianRightSecond = 8; 
    Vector3 pedestrianLeftOneOffset = new Vector3(pedestrianLeftFirst, 0, distanceDownTheRoad);
    Vector3 pedestrianLeftTwoOffset = new Vector3(pedestrianLeftSecond, 0, distanceDownTheRoad);
    Vector3 pedestrianRightOneOffset = new Vector3(pedestrianRightFirst, 0, distanceDownTheRoad);
    Vector3 pedestrianRightTwoOffset = new Vector3(pedestrianRightSecond, 0, distanceDownTheRoad);

    //Traffic lights
    public GameObject trafficLightLeft;
    public GameObject trafficLightRight;
    [SerializeField] static float trafficLightDistance = 30;
    [SerializeField] static float trafficLightOffset = 5.5f;
    Vector3 trafficLightPlacementLeft = new Vector3(-trafficLightOffset, 0, trafficLightDistance);
    Vector3 trafficLightPlacementRight = new Vector3(trafficLightOffset, 0, trafficLightDistance);

    //Crossings
    public GameObject crossingLeft;
    public GameObject crossingRight;
    Vector3 crossingPlacementLeft = new Vector3(-2.5f, 0, distanceDownTheRoad);
    Vector3 crossingPlacementRight = new Vector3(2.5f, 0, distanceDownTheRoad);

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Spawned a scenario");
            //Pedestrians
            Instantiate(pedestrianLeftOne, transform.position + pedestrianLeftOneOffset, transform.rotation);
            Instantiate(pedestrianLeftTwo, transform.position + pedestrianLeftTwoOffset, transform.rotation);
            Instantiate(pedestrianRightOne, transform.position + pedestrianRightOneOffset, transform.rotation);
            Instantiate(pedestrianRightTwo, transform.position + pedestrianRightTwoOffset, transform.rotation);

            //Traffic lights
            Instantiate(trafficLightLeft, transform.position + trafficLightPlacementLeft, transform.rotation);
            Instantiate(trafficLightRight, transform.position + trafficLightPlacementRight, transform.rotation);

            //Crossings
            Instantiate(crossingLeft, transform.position + crossingPlacementLeft, transform.rotation);
            Instantiate(crossingRight, transform.position + crossingPlacementRight, transform.rotation);
        }
    }
}
