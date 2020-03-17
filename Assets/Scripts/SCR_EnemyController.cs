using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_EnemyController : MonoBehaviour
{
    
    public float moveSpeed = 4;
    public float knockbackForce;


    private Rigidbody enemyRigidBody;
    private SCR_PlayerCombat playerReferance;
    private Vector3 knockbackDirection;

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
            playerReferance = movement.GetComponent<SCR_PlayerCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        //makes enemy walk directly towards player current position
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        //Destroy(gameObject,Random.Range(7.0f,12.0f));
    }

    private void OnTriggerStay(Collider other)
    {
        //Apply knockback when hit by attack range 
        if(other.gameObject.tag == "Attack")
        {
            if(playerReferance.isAttacking == true)
            {
                knockbackDirection = enemyRigidBody.transform.position - other.transform.position;
                enemyRigidBody.AddForce(knockbackDirection.normalized * knockbackForce);
            }
            Debug.Log("I GOT HIT"); 

;
        }
    }
}