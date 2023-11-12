using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightTimer : MonoBehaviour
{
    [SerializeField] float waitTime = 20;
    [SerializeField] float timer = 0;
    public Material greenLight;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(TrafficLightInternalTimer()); //StartCoroutine must be in Start() to avoid being called every frame and ruining timer
    }

    // Update is called once per frame
    void Update()
    {
        if(timer == waitTime)
        {
            Debug.Log("Light switches");
            animator.SetBool("IsGreen", true);
            //GetComponent<Renderer>().material = greenLight;
        }
    }

    IEnumerator TrafficLightInternalTimer()
    {
        while(timer < waitTime)
        {
            Debug.Log("A second has passed");
            yield return new WaitForSeconds(1);
            timer++;
        }
        
    }
}
