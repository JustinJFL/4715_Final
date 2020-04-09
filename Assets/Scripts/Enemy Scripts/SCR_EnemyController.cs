using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SCR_EnemyController : MonoBehaviour
{   
    public float moveSpeed = 4;
    public float knockbackForce;

    private Rigidbody enemyRigidBody;
    private SCR_PlayerCombat playerAttack;
    private Vector3 knockbackDirection;

    public Scrollbar enemyHealthBar;
    //Target attached to the camera for the health bar to orient itself toward the camera.
    public SCR_EnemySight enemySight;
    public GameObject enemyHealthBarTarget;

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
    }

    // Update is called once per frame
    void Update()
    {
        //makes enemy walk directly towards player current position
        if(enemySight.isPlayerSpotted == true)
        {
            transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }

        //Destroy(gameObject,Random.Range(7.0f,12.0f));

        //Updating transformation of health bar object to face the target attached to player camera.
        enemyHealthBar.transform.LookAt(enemyHealthBarTarget.transform.position);
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

}