using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SCR_PlayerCollider : MonoBehaviour
{
    public int startHealth;
    public int takenDamage; // Damage player takes from touching enemy hurtbox.
    public int curHealth;

    public Scrollbar playerHealthBar;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            curHealth -= takenDamage;
        
            //setting the size of the health bar to reflect players current health.
            playerHealthBar.size -= (takenDamage *.01f);
        }
    }
}
