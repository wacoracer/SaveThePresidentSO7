using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainFollow : MonoBehaviour
{
    [SerializeField] GameObject thingToFollow;
    
    void LateUpdate()
    {
        transform.position = thingToFollow.transform.position + new Vector3(-1, 10, 11);
    }
}
