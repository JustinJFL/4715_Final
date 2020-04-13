﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using TMPro;

public class SCR_GameManager : MonoBehaviour
{
    public static SCR_GameManager Instance;
    private float storePoints;
    private float totalPoints = 0;
    [SerializeField]
    public float pickupPoints;
    public bool groupAlert;
    public TextMeshProUGUI scoreText;

    public AudioSource playerDeathSFX;

    private SCR_PlayerHealth playerObject;
    private bool playerDeath = false;
    public GameObject playerDeathFX;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.LogWarning("PRESSING Q WILL OPEN A TEST SCENE THIS IS A FOR DEBUGGING PURPOSES AND MUST BE CHANGED IN THE FINAL BUILD");
        Screen.SetResolution(1920, 1080, true);
        Debug.Log("ass");
        //scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.SetText("Score: 0");
        scoreText.ForceMeshUpdate(true);
        GameObject player = GameObject.FindWithTag("Player");
        if(player != null)
        {
            playerObject = player.GetComponent<SCR_PlayerHealth>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerObject.curHealth <=0 & playerDeath == false)
        {
            playerDeathSFX.Play();
            playerDeath = true;
            playerDeathFX.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void UpdateTotalPoints(float points)
    {
        totalPoints += points;
        Debug.Log("Score " + totalPoints);
        scoreText.SetText("Score: " + totalPoints.ToString());
    }
    //Call this went subtracting from store points. enter a negative number to subtract.
    public void UpdateStorePoints(float points)
    {
        storePoints += points;
    }
}
