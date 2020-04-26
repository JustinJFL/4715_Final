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
            if(SceneManager.GetActiveScene().name == "BlockMesh")
            {
                GameObject.FindWithTag("GameController").GetComponent<SCR_GameManager>().lastLevel++;
                GameObject.FindWithTag("HUD").GetComponent<Canvas>().enabled = false;
                SceneManager.LoadScene("UpgradeShop", LoadSceneMode.Single);
                DontDestroyOnLoad(GameObject.FindWithTag("GameController"));
                DontDestroyOnLoad(GameObject.Find("CameraTarget"));
                DontDestroyOnLoad(GameObject.FindWithTag("HUD"));
                DontDestroyOnLoad(GameObject.Find("EventSystem"));
            }
            else if(SceneManager.GetActiveScene().name == "Level 2")
            {
                GameObject.FindWithTag("HUD").GetComponent<Canvas>().enabled = false;
                SceneManager.LoadScene("UpgradeShop", LoadSceneMode.Single);
            }
        }
    }
}
