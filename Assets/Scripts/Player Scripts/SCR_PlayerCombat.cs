 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PlayerCombat : MonoBehaviour
{

    private Rigidbody playerRigidBody;
    private Animator combatAnimator;
    private SCR_PlayerHealth playerHealth;

    public float knockbackForce;
    public bool isAttacking = false;
    public Attack playerAttack = new Attack(0, 30, 50);
    public Knockback playerAttackKnockback = new Knockback(0f, 500f, 700f);
    public GameObject LightAttackHitbox;
    public GameObject HeavyAttackHitbox;

    [System.Serializable]
    public class Attack
    {
        //Since Attacks do different amount of damage, this variable will be called by the enemy health script to 
        //apply damage to it
        public float damageOnHit = 0f;
        public float SwipeAttackDamage = 30f;
        public float HeavyAttackDamage = 50f;

        public Attack (int damage,int swipe, int heavy)
        {
            damageOnHit = damage;
            SwipeAttackDamage = swipe;
            HeavyAttackDamage = heavy;
        }
    }
    [System.Serializable]
    public class Knockback
    {
        //Same as damageOnHit
        public float knockbackOnHit = 0f;
        public float lightKnockback = 500f;
        public float heavyKnockback = 700f;
        public Knockback(float knockback, float lightKnock, float heavyKnock)
        {
            knockbackOnHit = knockback;
            lightKnockback = lightKnock;
            heavyKnockback = heavyKnock;
        }
    }



    private Vector3 knockbackDirection;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        combatAnimator = GetComponent<Animator>();
        playerHealth = GetComponent<SCR_PlayerHealth>();
        LightAttackHitbox.gameObject.SetActive(false);
        HeavyAttackHitbox.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("LightAttack"))
        {
            LightAttack();

        }
        else if(Input.GetButton("HeavyAttack"))
        {
            HeavyAttack();
        }
        
        //Ensures the hitboxes for attacking are disabled while the player is running or idle
        if(combatAnimator.GetCurrentAnimatorStateInfo(0).IsName("Run") 
        || combatAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            LightAttackHitbox.gameObject.SetActive(false);
            HeavyAttackHitbox.gameObject.SetActive(false);
        }

        SetToIdle();
    }

    void LightAttack()
    {
        //Checks if current animation state is on Idle
        if (combatAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            combatAnimator.SetBool("LightAttack", true);
            LightAttackHitbox.gameObject.SetActive(true);
            SetToIdle();
            isAttacking = true;
            playerAttack.damageOnHit = playerAttack.SwipeAttackDamage;
            playerAttackKnockback.knockbackOnHit = playerAttackKnockback.lightKnockback;
            playerHealth.timeSinceCombat = 0;
        }
    }
    void HeavyAttack()
    {
        Debug.Log("HEAVY ATTACK!!!");
        if(combatAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            combatAnimator.SetBool("HeavyAttack", true);
            HeavyAttackHitbox.gameObject.SetActive(true);
            SetToIdle();
            //isAttacking = true;
            playerAttack.damageOnHit = playerAttack.HeavyAttackDamage;
            playerAttackKnockback.knockbackOnHit = playerAttackKnockback.heavyKnockback;
            playerHealth.timeSinceCombat = 0;
        }
    }

    void SetToIdle()
    {
        //Checks if current animation state is on Swipe Attack
        if (combatAnimator.GetCurrentAnimatorStateInfo(0).IsName("SpinAttack"))
        {
            combatAnimator.SetBool("LightAttack", false);
            //isAttacking = false;
            LightAttackHitbox.gameObject.SetActive(false);
            //combatAnimator.SetBool("didRightWingAttack", true);
        }
        else if (combatAnimator.GetCurrentAnimatorStateInfo(0).IsName("PeckAttack"))
        {
            combatAnimator.SetBool("HeavyAttack", false);
            //isAttacking = false;
            HeavyAttackHitbox.gameObject.SetActive(false);
            //combatAnimator.SetBool("didRightWingAttack", false);
        }
        /*else if (combatAnimator.GetCurrentAnimatorStateInfo(0).IsName("ANIM_Heavy_Attack"))
        {
            if(combatAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
            combatAnimator.SetBool("LightAttack", false);
            isAttacking = false;
            LightAttackHitbox.gameObject.SetActive(false);
            combatAnimator.SetBool("didHeavyAttack", false);
            }

        }*/
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
