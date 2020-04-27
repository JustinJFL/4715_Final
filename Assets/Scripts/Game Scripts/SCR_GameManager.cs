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
    public static GameObject HUD;
    public float storePoints;

    [SerializeField]
    public bool upgrade1 = false;
    [SerializeField]
    public bool upgrade2 = false;
    [SerializeField]
    public bool upgrade3 = false;

    [SerializeField]
    public float totalPoints = 0;

    [SerializeField]
    public float actualTotalPoints = 0;

    [SerializeField]
    public float pickupPoints;
    public bool groupAlert;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    //public Canvas gameHUD;

    public AudioSource playerDeathSFX;
    public Transform levelTwoPlayerSpawn;
    public Transform levelThreePlayerSpawn;

    private SCR_PlayerHealth playerHealthScript;
    private bool playerDeath = false;
    public GameObject playerDeathFX;

    private GameObject player;
    private float highScore;

    private TextMeshProUGUI downedText;

    public int lastLevel;

    private int level2Loaded = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.LogWarning("PRESSING RIGHT CTRL TO RESET HIGH SCORE. CHANGE FOR DEBUGGING PURPOSES");
        //Screen.SetResolution(1920, 1080, true);
        Debug.Log("ASS");

        //scoreText = GetComponent<TextMeshProUGUI>();
        scoreText = GameObject.FindWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
        scoreText.SetText("0 Scrap");
        scoreText.ForceMeshUpdate(true);

        downedText = GameObject.FindWithTag("DownedText").GetComponent<TextMeshProUGUI>();
        downedText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(lastLevel.ToString() + " is the last level.");
        if(Input.GetKeyDown(KeyCode.RightControl))
        {
            Debug.Log("High Score Reset");
            PlayerPrefs.DeleteKey("HighScore");
        }
    

        if(SceneManager.GetActiveScene().name == "Level 2" && level2Loaded < 2)
        {
            //level2Loaded++;
            if(level2Loaded == 0)
            {
                GameObject.FindWithTag("HUD").GetComponent<Canvas>().enabled = true;
                playerHealthScript.curHealth = 100;
                playerHealthScript.curEnergy = 100;
                UpdateTotalPoints(0);
                level2Loaded++;
            }
            else
            {
                Debug.Log("Level 2 is loaded" + level2Loaded);
            }
            
        }
        if(SceneManager.GetActiveScene().name == "GameOver" 
        || SceneManager.GetActiveScene().name == "MainMenu")
        {
            //GameObject.FindWithTag("HUD").GetComponent<Canvas>().enabled = false;
        }
    }

    public void UpdateTotalPoints(float points)
    {
        totalPoints += points;
        actualTotalPoints += points;
        Debug.Log("Score " + totalPoints);
        scoreText.SetText(totalPoints.ToString() + " Scrap" );
        if (actualTotalPoints >= PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", actualTotalPoints);
        }

    }
    //Call this went subtracting from store points. enter a negative number to subtract.
    public void UpdateStorePoints(float points)
    {
        storePoints += points;
    }
}
