using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCR_Victory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
        Debug.Log("testing trigger for victory");
        if(other.gameObject.tag == "Player")
        {
        SceneManager.LoadScene("ShopMenu", LoadSceneMode.Single);
        }
    }
}
