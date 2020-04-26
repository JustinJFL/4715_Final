using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SCR_ScoreUpdate : MonoBehaviour
{
    private SCR_GameManager game;
    public TextMeshProUGUI currentScrap;
    public TextMeshProUGUI totalScrap; 
    // Start is called before the first frame update
    void Start()
    {
        GameObject controller = GameObject.FindWithTag("GameController");
        if (controller != null)
            game = controller.GetComponent<SCR_GameManager>();
        else
            Debug.Log("Game Manager script not found");
        currentScrap.SetText(": " + game.storePoints);
        totalScrap.SetText(": " + game.storePoints);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
