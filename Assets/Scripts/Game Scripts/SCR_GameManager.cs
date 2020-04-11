using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class SCR_GameManager : MonoBehaviour
{
    private float storePoints;
    private float totalPoints = 0;
    [SerializeField]
    public float pickupPoints;
    public bool groupAlert;
    public TextMeshProUGUI scoreText;

    public AudioSource playerDeathSFX;

    public GameObject playerObject;
    private bool playerDeath = false;
    public GameObject playerDeathFX;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        Debug.Log("ass");
        //scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.SetText("Score: 0");
        scoreText.ForceMeshUpdate(true);
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(playerObject.GetComponent<SCR_PlayerHealth>().curHealth <=0 & playerDeath == false)
        {
            playerDeathSFX.Play();
            playerDeath = true;
            playerDeathFX.SetActive(true);
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
