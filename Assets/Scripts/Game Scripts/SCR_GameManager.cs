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


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ass");
        //scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.SetText("Score: 0");
        scoreText.ForceMeshUpdate(true);
    }

    // Update is called once per frame
    void Update()
    {
        
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
