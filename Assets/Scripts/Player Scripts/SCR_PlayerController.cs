using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class SCR_PlayerController : MonoBehaviour
{

    [SerializeField]
    float speed = 4f;
    Vector3 forward, right;

    private Rigidbody playerRigidBody;
    private SCR_GameManager gameManager;

    public bool isAttacking = false;
    private Vector3 knockbackDirection;

    public float jumpForce;
    private Vector3 lookTarget;
    
    public Animator flamingoAnimator;

    public GameObject instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(GameObject.FindWithTag("Player"));
            return;
        }

        instance = GameObject.FindWithTag("Player");
        DontDestroyOnLoad(instance);
    }

    // Start is called before the first frame update
    void Start()
    {
        //Declaring forward variables to be based off of cameras position
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0,90,0))*forward;

        playerRigidBody = GetComponent<Rigidbody>();

        GameObject game = GameObject.FindWithTag("GameController");
        if (game != null)
        {
            gameManager = game.GetComponent<SCR_GameManager>();
        }
        else
            Debug.Log("Could not find object with Game Manager");
    }

    // Update is called once per frame
    void Update()
    {
        //Calling move function anytime the movement keys are pressed.
        if(Input.GetAxis("Horizontal") > .2 
        || Input.GetAxis("Vertical") > .2 
        || Input.GetAxis("Horizontal") < -.2 
        || Input.GetAxis("Vertical") < -.2)
            {
                Move();
            }
        else 
        {
            flamingoAnimator.SetBool("isRunning",false);
        }

        if(flamingoAnimator.GetBool("isRunning") == true)
        {
            this.GetComponent<SCR_PlayerLookControls>().enabled = false;
        }
        else if (flamingoAnimator.GetBool("isRunning") == false)
        {
            this.GetComponent<SCR_PlayerLookControls>().enabled = true;
        }
    }

    void Move()
    {
        //Getting different vector3 values for both the horizontal movement and vertical movement to set transform of player
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        Vector3 rightMovement = right * speed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * speed * Time.deltaTime * Input.GetAxis("Vertical");
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        //Using previously declared values to update players transform and movement based off camera position.
        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
        
        flamingoAnimator.SetBool("isRunning",true);
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
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Pickups")
        {
            Destroy(other.gameObject);
            gameManager.UpdateStorePoints(gameManager.pickupPoints);
            gameManager.UpdateTotalPoints(100);
        }
    }
}
