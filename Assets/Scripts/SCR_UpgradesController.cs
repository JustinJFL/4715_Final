﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class SCR_UpgradesController : MonoBehaviour
{
        public GameObject upgrade1Description;
        public GameObject upgrade1Video;
        public GameObject upgrade2Description;
        public GameObject upgrade2Video;
        public GameObject upgrade3Description;
        public GameObject upgrade3Video;

        private GameObject player;
        private SCR_PlayerHealth playerHealthScript;
        private SCR_PlayerCombat playerCombatScript;
        private SCR_PlayerController playerControllerScript;

        private bool upgrade1Purchased = false;
        private bool upgrade2Purchased = false;
        private bool upgrade3Purchased = false;

        public int lastLevel;

        private GameObject gameController;



    private void Start() 
    {
        player = GameObject.FindWithTag("Player");
        playerHealthScript = player.GetComponent<SCR_PlayerHealth>();
        playerCombatScript = player.GetComponent<SCR_PlayerCombat>();
        playerControllerScript = player.GetComponent<SCR_PlayerController>();
        gameController = GameObject.FindWithTag("GameController");
        lastLevel = gameController.GetComponent<SCR_GameManager>().lastLevel;
    }

    public void upgrade1Variables(bool upgrade1)
    {
        if(upgrade1)
        {
            upgrade1Description.SetActive(true);
            upgrade1Video.SetActive(true);
        }
    }

    public void upgrade2Variables(bool upgrade2)
    {
        if(upgrade2)
        {
            upgrade2Description.SetActive(true);
            upgrade2Video.SetActive(true);
        }
    }

    public void upgrade3Variables(bool upgrade3)
    {
        if(upgrade3)
        {
            upgrade3Description.SetActive(true);
            upgrade3Video.SetActive(true);
        }
    }

    public void upgrade1()
    {
        playerHealthScript.takenDamage = 5;
        upgrade1Purchased = true;
    }

    public void upgrade2()
    {
        playerControllerScript.speed = 11;
        upgrade2Purchased = true;
    }

    public void upgrade3()
    {
        playerCombatScript.playerAttack.SwipeAttackDamage = 45;
        playerCombatScript.playerAttack.HeavyAttackDamage = 65;
        upgrade3Purchased = true;
    }

    public void loadNextlevel()
    {
        if(lastLevel == 1)
        {
            //GameObject.FindWithTag("HUD").GetComponent<Canvas>().enabled = true;
            SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
        }

        else if(lastLevel == 2)
        {
            //GameObject.FindWithTag("HUD").GetComponent<Canvas>().enabled = true;
            SceneManager.LoadScene("Level 3", LoadSceneMode.Single);
        }
    }

}