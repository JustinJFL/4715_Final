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
        Debug.Log("PRESSING Q TAKES YOU TO LEVEL 2 PLEASE REMOVE BEFORE BUILD");
        if(Input.GetKeyDown(KeyCode.Q))
        {
                    GameObject.FindWithTag("GameController").GetComponent<SCR_GameManager>().lastLevel+= 2;
                GameObject.FindWithTag("HUD").GetComponent<Canvas>().enabled = false;
                SceneManager.LoadScene("UpgradeShop", LoadSceneMode.Single);

                DontDestroyOnLoad(GameObject.FindWithTag("GameController"));

                DontDestroyOnLoad(GameObject.Find("CameraTarget"));

                DontDestroyOnLoad(GameObject.FindWithTag("HUD"));

                DontDestroyOnLoad(GameObject.Find("EventSystem"));

                GameObject.FindWithTag("Tutorial").GetComponent<SCR_Tutorial_Menus>().PopUpCounter();
            
        }
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

                GameObject.FindWithTag("Tutorial").GetComponent<SCR_Tutorial_Menus>().PopUpCounter();
            }
            else if(SceneManager.GetActiveScene().name == "Level 2")
            {
                GameObject.FindWithTag("GameController").GetComponent<SCR_GameManager>().lastLevel++;
                GameObject.FindWithTag("HUD").GetComponent<Canvas>().enabled = false;
                SceneManager.LoadScene("UpgradeShop", LoadSceneMode.Single);

                GameObject.FindWithTag("Tutorial").GetComponent<SCR_Tutorial_Menus>().PopUpCounter();
            }

            else if(SceneManager.GetActiveScene().name == "Level 3")
            {
                Destroy(GameObject.FindWithTag("GameController"));
                Destroy(GameObject.Find("CameraTarget"));
                Destroy(GameObject.FindWithTag("HUD"));
                Destroy(GameObject.Find("EventSystem"));
                Destroy(GameObject.FindWithTag("Player"));
                SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
            }
        }
    }
}
