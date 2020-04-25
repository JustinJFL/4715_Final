using System.Collections;
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

    private SCR_PlayerHealth playerHealthScript;
    private bool playerDeath = false;
    public GameObject playerDeathFX;

    private GameObject player;

    private TextMeshProUGUI downedText;

    public int lastLevel;

    private int level2Loaded = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        DontDestroyOnLoad(GameObject.Find("CameraTarget"));
        DontDestroyOnLoad(GameObject.FindWithTag("HUD"));
        DontDestroyOnLoad(GameObject.Find("EventSystem"));
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.LogWarning("PRESSING Q WILL OPEN A TEST SCENE THIS IS A FOR DEBUGGING PURPOSES AND MUST BE CHANGED IN THE FINAL BUILD");
        Screen.SetResolution(1920, 1080, true);
        Debug.Log("ass");
        //scoreText = GetComponent<TextMeshProUGUI>();
        scoreText = GameObject.FindWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
        scoreText.SetText("Scrap: 0");
        scoreText.ForceMeshUpdate(true);
        GameObject player = GameObject.FindWithTag("Player");
        if(player != null)
        {
            playerHealthScript = player.GetComponent<SCR_PlayerHealth>();
        }
        
        player = GameObject.FindWithTag("Player");

        downedText = GameObject.FindWithTag("DownedText").GetComponent<TextMeshProUGUI>();
        downedText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealthScript.curHealth <=0 & playerDeath == false)
        {
            playerDeathSFX.Play();
            playerDeath = true;
            playerDeathFX.SetActive(true);
        }

        Debug.Log(lastLevel.ToString() + " is the last level.");
    

        if(SceneManager.GetActiveScene().name == "Level 2" && level2Loaded < 2)
        {
            level2Loaded++;
            if(level2Loaded == 1)
            {
                GameObject.FindWithTag("HUD").GetComponent<Canvas>().enabled = true;
                playerHealthScript.curHealth = 100;
                playerHealthScript.curEnergy = 100;
                UpdateTotalPoints(0);
            }
            else
            {
                Debug.Log("Level 2 is loaded" + level2Loaded);
            }
            
        }
        if(SceneManager.GetActiveScene().name == "GameOver")
        {
            GameObject.FindWithTag("HUD").GetComponent<Canvas>().enabled = false;
        }
    }

    public void UpdateTotalPoints(float points)
    {
        totalPoints += points;
        Debug.Log("Score " + totalPoints);
        scoreText.SetText("Scrap: " + totalPoints.ToString());
    }
    //Call this went subtracting from store points. enter a negative number to subtract.
    public void UpdateStorePoints(float points)
    {
        storePoints += points;
    }
}
