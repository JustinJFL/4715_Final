// Connected to energy bar in SCR_PlayerHealth
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PowerSap : MonoBehaviour
{
    public static bool isCharging = false;
    public GameObject player;


    //private int i;
    private float tmp;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Downed" && Input.GetKeyDown(KeyCode.C)) // Set defeated enemy model to have the tag Downed
        {
            if (isCharging == false)
            {
                StartCoroutine(Drain());
                GameObject.Destroy(other);
            }

            else
            {
                Stop();
            }
        }
    }

    IEnumerator Drain()
    {
        isCharging = true;
        player.GetComponent<SCR_PlayerMovement>().enabled = false;
        Debug.Log("Charging...");
        
        tmp = player.GetComponent<SCR_PlayerHealth>().curEnergy;
        player.GetComponent<SCR_PlayerHealth>().energyDecreaseRate = -30;

        yield return new WaitForSeconds(5);
        player.GetComponent<SCR_PlayerMovement>().enabled = true;
    }

    void Stop()
    {
        isCharging = false;
        player.GetComponent<SCR_PlayerMovement>().enabled = true;
        Debug.Log("Charge stopped.");
        player.GetComponent<SCR_PlayerHealth>().curEnergy = tmp;
        player.GetComponent<SCR_PlayerHealth>().energyDecreaseRate = 20;
    }
}
