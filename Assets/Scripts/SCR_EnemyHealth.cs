using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SCR_EnemyHealth : MonoBehaviour
{
    public int totalHealth;
    public int takenDamage; // Damage taken from touching player's weapon.
    public GameObject pickup;
    public float dropAmount;

    public Scrollbar enemyHealthBar;

    private int curHealth;
    private SCR_PlayerCombat playerReferance;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = totalHealth;
        enemyHealthBar.size = 1;
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
        if (curHealth <= 0)
        {
            Destroy(gameObject);
            //Spawn an item on enemy's death?
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Attack") //If the enemy is hit with the theoretical "weapon," they take damage.
        {
            curHealth -= takenDamage;
            enemyHealthBar.size -= (takenDamage * .01f);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (curHealth == 0)
        {
            for (int i = 0; i < dropAmount; i++)
            {
                float posX = transform.position.x + Random.Range(-2, 2);
                float posZ = transform.position.z + Random.Range(-2, 2);
                Instantiate(pickup, new Vector3(posX, transform.position.y, posZ), Quaternion.identity);
            }
            Destroy(this.gameObject);
            Debug.Log("I GOT HIT");
        }


    }
}
