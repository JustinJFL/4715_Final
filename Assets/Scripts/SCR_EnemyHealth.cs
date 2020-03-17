using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_EnemyHealth : MonoBehaviour
{
    public int totalHealth;
    public int takenDamage; // Damage taken from touching player's weapon.

    private int curHealth;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = totalHealth;
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
        }
    }
}
