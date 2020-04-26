using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Animations;

public class SCR_EnemyController : MonoBehaviour
{   
    public float moveSpeed = 4;
    public float knockbackForce;
    //public WanderBoundry wanderLimit;

    public bool isPlayerSpotted;

    private Rigidbody enemyRigidBody;
    private SCR_PlayerCombat playerAttack;
    private Vector3 knockbackDirection;
    private int attackNum;

    public Scrollbar enemyHealthBar;
    //Target attached to the camera for the health bar to orient itself toward the camera.
    //public SCR_EnemySight enemySight;
    public GameObject enemyHealthBarTarget;

    public Animator enemyAnimator;

    public bool setToIdle = false;

    private bool attack1;
    private bool attack2;
    private bool attack3;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody>();
        GameObject movement = GameObject.FindWithTag("Player");
        if (movement == null)
        {
            Debug.Log("Player Reference could not be found");
        }
        else
            playerAttack = movement.GetComponent<SCR_PlayerCombat>();

        //Object must be tagged with HealthTarget and attached to the camera gameobject so the enemy health bar can properly be oriented toward the camera.
        enemyHealthBarTarget = GameObject.FindWithTag("HealthTarget");

        //enemySight = GetComponent<SCR_EnemyBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyHealthBar.transform.LookAt(enemyHealthBarTarget.transform.position);
        //transform.LookAt(GameObject.FindWithTag("Player").transform.position);

        SetToIdle();
    
    }

    private void OnTriggerEnter(Collider other)
    {
        //Apply knockback when hit by attack range 
        if(other.gameObject.tag == "Attack")
        {
            if (playerAttack.isAttacking == true)
            {
                knockbackDirection = enemyRigidBody.transform.position - playerAttack.transform.position;
                enemyRigidBody.AddForce(knockbackDirection.normalized * playerAttack.playerAttackKnockback.knockbackOnHit);
                //this.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            //Debug.Log("I GOT HIT"); 
        }


    }
    private void OnCollisionEnter(Collision collision)

    {
        if(collision.gameObject.tag == "Player")
        {
            attackNum = Random.Range(1,4);
            enemyAnimator.SetInteger("AttackNum",attackNum);
            //enemyAnimator.SetInteger("AttackNum",0);
            //setToIdle = true;

            if (attackNum == 1)
            {
                enemyAnimator.SetInteger("AttackNum",1);
            }

            else if (attackNum == 2)
            {
                enemyAnimator.SetInteger("AttackNum",2);
            }

            else if (attackNum == 3)
            {
                enemyAnimator.SetInteger("AttackNum",3);
            }
        }

        if(collision.gameObject.tag == "Wall")

        {
            transform.eulerAngles = new Vector3(0, Random.Range(-360, 360), 0);
        }

    }
        void SetToIdle()
        {
           // attackNum = 0;
            //enemyAnimator.SetInteger("AttackNum",0);
            if(enemyAnimator.GetCurrentAnimatorStateInfo(1).IsName("Tail_Attack"))
            {
                enemyAnimator.SetInteger("AttackNum", 0); 
            }

            else if(enemyAnimator.GetCurrentAnimatorStateInfo(1).IsName("Wind_Up"))
            {
                enemyAnimator.SetInteger("AttackNum", 0);
            }

            else if(enemyAnimator.GetCurrentAnimatorStateInfo(1).IsName("Claw_attack"))
            {
                enemyAnimator.SetInteger("AttackNum", 0);
            }
        }
}