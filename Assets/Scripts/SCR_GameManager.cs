using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class SCR_GameManager : MonoBehaviour
{
    private float storePoints;
    private float totalPoints;
    [SerializeField]
    public float pickupPoints;

    public TextMeshPro scoreText;


    // Start is called before the first frame update
    void Start()
    {
       // scoreText = GameObject.Find("Score").GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTotalPoints(float points)
    {
        totalPoints += points;
        Debug.Log("Score " + totalPoints);
        //scoreText.text = "Score: " + totalPoints;
    }
    //Call this went subtracting from store points. enter a negative number to subtract.
    public void UpdateStorePoints(float points)
    {
        storePoints += points;
    }
}
