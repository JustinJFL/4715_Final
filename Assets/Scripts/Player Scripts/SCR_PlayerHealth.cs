﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SCR_PlayerHealth : MonoBehaviour
{
    public int startHealth;
    public int takenDamage; // Damage player takes from touching enemy hurtbox.
    public int curHealth;
    public float curEnergy;
    public float regenRate;

    public float energyDecreaseRate = 20;

    public Sprite[] healthSprites;//Array holding the sprites for health ring

    //Image variables accessing the respective Image gameobjects on the HUD canvas in scene. Must be publically defined in engine.
    public Image healthRingImage;
    public Image energyRingImage;
    public float curHealthSprite;

    public AudioSource enemyAttackSFX;
    public AudioSource playerDeathSFX;
    private float timeOfNoKeyPress;

    void Start()
    {
        //defining health and energy variables
        curHealth = startHealth;
        healthRingImage.sprite = healthSprites[10];
        curEnergy = startHealth;

        //playerHealthBar.size = 1;

        //Invokes function to slowly lose energy over time.
        InvokeRepeating("EnergyOverTime",.01f,.01f);

    }

    void Update()
    {
        //Changes the fill amount of the image to appear as though it is degrading.
        energyRingImage.fillAmount = (curEnergy * .01f);

        if(curHealth <= 0)
        {
            gameObject.SetActive(false); // Player Dies, made inactive for now. Scene Manager is set for future use.
            healthRingImage.sprite = healthSprites[0];
            SceneManager.LoadScene("GameOver",LoadSceneMode.Single);
        }
        if(!Input.anyKey && curHealth < 100)
        {

            timeOfNoKeyPress += Time.deltaTime;
            if (timeOfNoKeyPress >= RegenTime)
            {
                Debug.Log("Regenning...");
                curHealth += 10;
                timeOfNoKeyPress = 0;
                UpdateHealthSprite();
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("I'm Hit");
        if (collision.gameObject.tag == "Enemy")
        {

            curHealth -=  takenDamage;
            enemyAttackSFX.Play();
            //setting the size of the health bar to reflect players current health.
            UpdateHealthSprite();
        }
    }

//function that slowly degrades energy over time at a rate called in InvokeRepeating in Start function.
    void EnergyOverTime()
    {
        curEnergy = curEnergy - (energyDecreaseRate * .01f);
    }
    void UpdateHealthSprite()
    {
        curHealthSprite = (curHealth * 0.1f);
        healthRingImage.sprite = healthSprites[Mathf.RoundToInt(curHealthSprite)];
    }
}
