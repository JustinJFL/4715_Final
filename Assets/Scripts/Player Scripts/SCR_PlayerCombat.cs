using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PlayerCombat : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    private Animator combatAnimator;

    public float knockbackForce;
    public bool isAttacking = false;
    //Since Attacks do different amount of damage, this variable will be called by the enemy health script to 
    //apply damage to it 
    public float damageOnHit = 0f;
    public GameObject arm;

    [SerializeField]
    private float SwipeAttackDamage = 30f;
    private Vector3 knockbackDirection;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        combatAnimator = GetComponent<Animator>();
        arm.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Attack();

        }
        SetToIdle();
    }

    void Attack()
    {
        //Checks if current animation state is on Idle
        if (combatAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            Debug.Log("ATTACK!!!");
            combatAnimator.SetBool("isAttacking", true);
            arm.gameObject.SetActive(true);
            isAttacking = true;
            damageOnHit = SwipeAttackDamage;
        }
    }

    void SetToIdle()
    {
        //Checks if current animation state is on Swipe Attack
        if (combatAnimator.GetCurrentAnimatorStateInfo(0).IsName("ANIM_Swipe_Attack_1"))
        {
            combatAnimator.SetBool("isAttacking", false);
            isAttacking = false;
            arm.gameObject.SetActive(false);
            combatAnimator.SetBool("didRightWingAttack", true);
        }
        if (combatAnimator.GetCurrentAnimatorStateInfo(0).IsName("ANIM_Swipe_Attack_2"))
        {
            combatAnimator.SetBool("isAttacking", false);
            isAttacking = false;
            arm.gameObject.SetActive(false);
            combatAnimator.SetBool("didRightWingAttack", false);
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
