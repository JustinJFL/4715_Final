using System.Collections;
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
        if (gameController.GetComponent<SCR_GameManager>().totalPoints >= 3 && !gameController.GetComponent<SCR_GameManager>().upgrade1)
        {
            playerHealthScript.takenDamage = 5;
            gameController.GetComponent<SCR_GameManager>().totalPoints -= 3;
            gameController.GetComponent<SCR_GameManager>().upgrade1 = true;
            playerControllerScript.putOnBackpack();
        }
        
    }

    public void upgrade2()
    {
        if(gameController.GetComponent<SCR_GameManager>().totalPoints >= 4 && !gameController.GetComponent<SCR_GameManager>().upgrade2)
        {
            playerControllerScript.speed = 11;
            gameController.GetComponent<SCR_GameManager>().totalPoints -= 4;
            gameController.GetComponent<SCR_GameManager>().upgrade2 = true;
            playerControllerScript.paintLegs();

        }
    }

    public void upgrade3()
    {
        if (gameController.GetComponent<SCR_GameManager>().totalPoints >= 5 && !gameController.GetComponent<SCR_GameManager>().upgrade3)
        {
            playerCombatScript.playerAttack.SwipeAttackDamage = 45;
            playerCombatScript.playerAttack.HeavyAttackDamage = 65;
            gameController.GetComponent<SCR_GameManager>().totalPoints -= 5;
            gameController.GetComponent<SCR_GameManager>().upgrade3 = true;
            playerControllerScript.paintWings();
        }
    }

    public void loadNextlevel()
    {
        if(lastLevel == 1)
        {
            //GameObject.FindWithTag("HUD").GetComponent<Canvas>().enabled = true;
            SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
            player.transform.position = gameController.GetComponent<SCR_GameManager>().levelTwoPlayerSpawn.transform.position;
        }

        else if(lastLevel == 2)
        {
            //GameObject.FindWithTag("HUD").GetComponent<Canvas>().enabled = true;
            SceneManager.LoadScene("Level 3", LoadSceneMode.Single);
        }
    }

}
