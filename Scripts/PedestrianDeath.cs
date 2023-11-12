using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianDeath : MonoBehaviour
{
    //Death sound
    public AudioClip manScreamOne;
    public AudioClip manScreamTwo;
    public AudioClip womanScreamOne;
    public AudioClip womanScreamTwo;
    AudioSource sourceOfScream;
    private Animator animator;
    

    void Awake()
    {
        sourceOfScream = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            
            if(tag == "AdultMan" || tag == "OldMan" || tag == "YoungBoy")
            {
                if(Random.Range(0,2) == 0)
                {
                    //sourceOfScream.clip = manScreamOne;
                    sourceOfScream.PlayOneShot(manScreamOne);

                    Debug.Log("played manScreamOne");
                }

                else
                {
                    //sourceOfScream.clip = manScreamTwo;
                    sourceOfScream.PlayOneShot(manScreamTwo);
                    Debug.Log("played manScreamTwo");
                }
            }

            if(tag == "AdultWoman" || tag == "OldWoman" || tag == "YoungGirl")
            {
                if(Random.Range(0,2) == 0)
                {
                    //sourceOfScream.clip = womanScreamOne;
                    sourceOfScream.PlayOneShot(womanScreamOne);
                    Debug.Log("played womanScreamOne");
                }

                else
                {
                    //sourceOfScream.clip = womanScreamTwo;
                    sourceOfScream.PlayOneShot(womanScreamTwo);
                    Debug.Log("played womanScreamTwo");
                }
            }
            name = "Dying";
            animator.SetBool("isDead", true);
            
            gameObject.GetComponent<MeshCollider>().enabled = false;
            gameObject.GetComponent<PedestrianMovement>().enabled = false;


            Destroy(gameObject,3f);
        }
    }

}
