using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SCR_EnemyController : MonoBehaviour
{
    
    public float moveSpeed = 4;
    public float knockbackForce;
    public GameObject pickup;
    public float dropAmount;

    private Rigidbody enemyRigidBody;
    private SCR_PlayerCombat playerReferance;
    private Vector3 knockbackDirection;

    public Scrollbar enemyHealthBar;
    public GameObject enemyHealthBarTarget; //Target attached to the camera for the health bar to orient itself toward the camera.

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

        //Object must be tagged with HealthTarget and attached to the camera gameobject so the enemy health bar can properly be oriented toward the camera.
        enemyHealthBarTarget = GameObject.FindWithTag("HealthTarget");
    }

    // Update is called once per frame
    void Update()
    {
        //makes enemy walk directly towards player current position
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        //Destroy(gameObject,Random.Range(7.0f,12.0f));

        //Updating transformation of health bar object to face the target attached to player camera.
        enemyHealthBar.transform.LookAt(enemyHealthBarTarget.transform.position);
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
                //this.gameObject.GetComponent<BoxCollider>().enabled = false;
                for(int i = 0; i < dropAmount; i++)
                {
                    float posX = transform.position.x + Random.Range(-2, 2);
                    float posZ = transform.position.z + Random.Range(-2,2);
                    Instantiate(pickup, new Vector3(posX, transform.position.y, posZ), Quaternion.identity);
                }
                Destroy(this.gameObject);
            }
            Debug.Log("I GOT HIT"); 

;
        }
        // transform.position + new Vector3(posX, transform.position.y,posX)
    }
}