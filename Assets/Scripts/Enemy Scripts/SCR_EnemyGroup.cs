using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_EnemyGroup : MonoBehaviour
{
    public SCR_EnemyController[] enemies;
    private SCR_GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        GameObject game = GameObject.FindWithTag("GameController");
        if(game == null)
        {
            Debug.Log("Game Manager not found");
        }
        gameManager = game.GetComponent<SCR_GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.groupAlert)
        {
            for (int i = 0; i < enemies.Length; i++)
                enemies[i].isPlayerSpotted = true;
        }
    }
}
