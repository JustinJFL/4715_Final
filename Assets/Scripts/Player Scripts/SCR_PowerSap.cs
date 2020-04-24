// Connected to energy bar in SCR_PlayerHealth
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PowerSap : MonoBehaviour
{
    public static bool onEnemy = false;
    public static bool isCharging = false;
    public GameObject player;


    //private int i;
    private float tmp;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Charge") && onEnemy == true)
        {
            if (isCharging == false)
            {
                StartCoroutine(Drain());
                //GameObject.Destroy(other);
            }

            else
            {
                Stop();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Downed") // Set defeated enemy model to have the tag Downed
        {
            onEnemy = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Downed") // Set defeated enemy model to have the tag Downed
        {
            onEnemy = false;
        }
    }

    IEnumerator Drain()
    {
        isCharging = true;
        player.GetComponent<SCR_PlayerController>().enabled = false;
        Debug.Log("Charging...");
        
        tmp = player.GetComponent<SCR_PlayerHealth>().curEnergy;
        player.GetComponent<SCR_PlayerHealth>().energyDecreaseRate = -3;

        yield return new WaitForSeconds(5);
        Debug.Log("Target drained.");
        isCharging = false;
        player.GetComponent<SCR_PlayerController>().enabled = true;
        player.GetComponent<SCR_PlayerHealth>().energyDecreaseRate = 2;
        onEnemy = false;
    }

    void Stop()
    {
        isCharging = false;
        player.GetComponent<SCR_PlayerController>().enabled = true;
        Debug.Log("Charge stopped.");
        player.GetComponent<SCR_PlayerHealth>().curEnergy = tmp;
        player.GetComponent<SCR_PlayerHealth>().energyDecreaseRate = 2;
    }
}
