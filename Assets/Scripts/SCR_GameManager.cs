using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_GameManager : MonoBehaviour
{
    private float storePoints;
    private float totalPoints;
    [SerializeField]
    public float pickupPoints;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTotalPoints(float points)
    {
        totalPoints += points;
    }
    //Call this went subtracting from store points. enter a negative number to subtract.
    public void UpdateStorePoints(float points)
    {
        storePoints += points;
    }
}
