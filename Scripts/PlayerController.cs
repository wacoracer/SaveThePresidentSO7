using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3; //Defining Vector3 as it is exists in both System.Numerics and UnityEngine and causes a compiling error

public class PlayerController : MonoBehaviour
{
    
    Rigidbody rb; //Rigidbody
    [SerializeField] float speed = 5; //Forward speed multiplier
    [SerializeField] float turnSpeed = 5; //Amount the car should move per second during lane switch
    [SerializeField] float maxTurn = 1; //Amount you can move away from x=0 before you hit the edge
    Vector3 driving = new Vector3(0, 0, 0); //Defines the driving vector so I can use it in the code. This can be done within update, but there's no need to do it every frame

    public bool isTurningLeft = false;
    public bool isTurningRight = false;

    float hitAPersonSpeed = 1;
    float speedDebuff = 0.75f;
    // Start is called before the first frame update
    void Start()
    {
        //Get RigidBody 
        rb = GetComponent<Rigidbody>();

    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") < 0)
        {
            isTurningLeft = true;
            isTurningRight = false;
        }

        if(Input.GetAxis("Horizontal") == 0)
        {
            isTurningLeft = false;
            isTurningRight = false;
        }

        if(Input.GetAxis("Horizontal") > 0)
        {
            isTurningLeft = false;
            isTurningRight = true;
        }
    }


    void FixedUpdate()
    {        
        if(GameObject.Find("Dying"))
        {
            hitAPersonSpeed = speedDebuff;
        }

        else
        {
            hitAPersonSpeed = 1;
        }
        
        //Car driving forwards
        if(Input.GetAxis("Vertical") > 0) //Redefines vector so you can drive forwards
        {
            driving = new Vector3(Input.GetAxis("Horizontal") * turnSpeed, 0, Input.GetAxis("Vertical") * speed * hitAPersonSpeed);
            rb.MovePosition(transform.position + driving * Time.fixedDeltaTime);
            Debug.Log("You are driving :)");
        }

        else //Redefines vector so you can't reverse
        {
            driving = new Vector3(Input.GetAxis("Horizontal") * turnSpeed, 0, 0);
            rb.MovePosition(transform.position + driving * Time.fixedDeltaTime);
            Debug.Log("You tried to reverse");
        }

        if(rb.position.x > maxTurn)
        {
            if(Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") >= 0) //Redefines vector so you turn more left but still drive forwards
            {
                driving = new Vector3(0, 0, Input.GetAxis("Vertical") * speed * hitAPersonSpeed);
                rb.MovePosition(transform.position + driving * Time.fixedDeltaTime);
                Debug.Log("You hit the right wall");
            }

            else if(Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") < 0) //Redefines vector so you can't go further left or go backwards
            {
                driving = new Vector3(0, 0, 0);
                rb.MovePosition(transform.position + driving * Time.fixedDeltaTime);
                Debug.Log("You hit the right wall and tried to back up... Bruh.");
            }

            else
            {
                Debug.Log("Continue as you wish");
            }
        }

        else if(rb.position.x < -maxTurn)
        {
            if(Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") >= 0) //Redefines vector so you turn more left but still drive forwards
            {
                driving = new Vector3(0, 0, Input.GetAxis("Vertical") * speed * hitAPersonSpeed);
                rb.MovePosition(transform.position + driving * Time.fixedDeltaTime);
                Debug.Log("You hit the left wall");
            }

            else if(Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") < 0) //Redefines vector so you can't go further left or go backwards
            {
                driving = new Vector3(0, 0, 0);
                rb.MovePosition(transform.position + driving * Time.fixedDeltaTime);
                Debug.Log("You hit the left wall and tried to back up... Bruh.");
            }

            else
            {
                Debug.Log("Continue as you wish");
            }

            
        }




    }

}
