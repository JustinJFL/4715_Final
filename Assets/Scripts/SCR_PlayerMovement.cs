using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SCR_PlayerMovement : MonoBehaviour
{

    [SerializeField]
    float speed = 4f;
    Vector3 forward, right;

    private Rigidbody playerRigidBody;

    public bool isAttacking = false;
    private Vector3 knockbackDirection;

    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        //Declaring forward variables to be based off of cameras position
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0,90,0))*forward;
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Calling move function anytime the movement keys are pressed.
        if(Input.GetAxis("HorizontalKey") > 0 
        || Input.GetAxis("VerticalKey") > 0 
        || Input.GetAxis("HorizontalKey") < 0 
        || Input.GetAxis("VerticalKey") < 0)
            {
                Move();
            }
        //Attacking with Left Mouse Button

    }

    void Move()
    {
        //Getting different vector3 values for both the horizontal movement and vertical movement to set transform of player
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"),0,Input.GetAxis("VerticalKey"));
        Vector3 rightMovement = right * speed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * speed * Time.deltaTime * Input.GetAxis("VerticalKey");
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        //Using previously declared values to update players transform and movement based off camera position.
        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
    }
    void Jump()
    {   
        //Called at OnCollisionStay,force determined by mass and jumpForce
        playerRigidBody.AddForce(transform.up * jumpForce);
    }


    private void OnCollisionStay(Collision collision)
    {
        //ground check  to prevent infinite jumping
        if(collision.gameObject.tag == "Ground")
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
    }

}
