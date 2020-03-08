using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SCR_PlayerMovement : MonoBehaviour
{

    [SerializeField]
    float speed = 4f;
    Vector3 forward, right;
    private Rigidbody rigid;
    private bool isAttacking = false;
    public Animator combatAnimator;
    private Animation swipe; 

    public float jumpForce;
    
    // Start is called before the first frame update
    void Start()
    {
        //Declaring forward variables to be based off of cameras position
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0,90,0))*forward;

        rigid = GetComponent<Rigidbody>();
        combatAnimator = GetComponent<Animator>();
        swipe = GetComponent<Animation>();
        
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
        if(Input.GetMouseButton(0))
        {
            Attack();
        }
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
        rigid.AddForce(transform.up * jumpForce);
    }

    void Attack()
    {
        if (combatAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            Debug.Log("ATTACK!!!");
            combatAnimator.SetBool("isAttacking", true);

            isAttacking = true;
        }
        if (combatAnimator.GetCurrentAnimatorStateInfo(0).IsName("Swipe Attack"))
        {
            combatAnimator.SetBool("isAttacking", false);
            isAttacking = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Enemy")
        {
            if(isAttacking == true)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
