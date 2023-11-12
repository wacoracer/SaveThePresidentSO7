using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class ERSpawner : MonoBehaviour
{
    public GameObject ER;
    public static bool ERSpawned = false;
    [SerializeField] static float ERDisplacement = 264;
    //ER placement == 266 (108 * 2 + 50) - current placement on road piece 
    Vector3 ERPlacement = new Vector3(0,-1,ERDisplacement);
        
    void Awake()
    {
        ERSpawned = false;
        if(GameObject.FindWithTag("DoIExist").GetComponent<EndlessPedestrianSpawner>().endlessStatusCarrier)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Instantiate(ER, transform.position + ERPlacement, transform.rotation);
            ERSpawned = true;
            Destroy(gameObject);
        }
    }
}
