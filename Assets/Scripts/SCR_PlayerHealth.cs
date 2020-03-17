using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCR_PlayerHealth : MonoBehaviour
{
    public int startHealth;
    public int takenDamage; // Damage player takes from touching enemy hurtbox.

    private int curHealth;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(curHealth <= 0)
        {
            gameObject.SetActive(false); // Player Dies, made inactive for now. Scene Manager is set for future use.
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            curHealth -= takenDamage;
        }
    }
}
