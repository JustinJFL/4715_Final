using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PlayerCombat : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    private Animator combatAnimator;

    public float knockbackForce;
    public bool isAttacking = false;
    private Vector3 knockbackDirection;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        combatAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Attack();

        }
            //Checks if current animation state is on Swipe Attack
        if (combatAnimator.GetCurrentAnimatorStateInfo(0).IsName("Swipe Attack"))
        {
            combatAnimator.SetBool("isAttacking", false);
            isAttacking = false;
        }
    }

    void Attack()
    {
        //Checks if current animation state is on Idle
        if (combatAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            Debug.Log("ATTACK!!!");
            combatAnimator.SetBool("isAttacking", true);

            isAttacking = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Apply knockback when hit by enemy, knockback power will change based on enemy
        if (collision.gameObject.tag == "Enemy")
        {
            //Debug.Log("I GOT HIT");
            knockbackDirection = playerRigidBody.transform.position - collision.transform.position;
            playerRigidBody.AddForce(knockbackDirection.normalized * knockbackForce);

        }
    }
}
