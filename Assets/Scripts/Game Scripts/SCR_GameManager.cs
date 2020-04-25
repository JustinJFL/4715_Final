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
    public float storePoints;
    public float totalPoints = 0;
    [SerializeField]
    public float pickupPoints;
    public bool groupAlert;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    //public Canvas gameHUD;

    public AudioSource playerDeathSFX;

    private SCR_PlayerHealth playerHealthScript;
    private bool playerDeath = false;
    public GameObject playerDeathFX;

    private GameObject player;
    private float highScore;

    private TextMeshProUGUI downedText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.LogWarning("PRESSING Q WILL OPEN A TEST SCENE THIS IS A FOR DEBUGGING PURPOSES AND MUST BE CHANGED IN THE FINAL BUILD");
        Debug.LogWarning("PRESSING RIGHT CTRL TO RESET HIGH SCORE. CHANGE FOR DEBUGGING PURPOSES");
        Screen.SetResolution(1920, 1080, true);
        Debug.Log("ASS");

        //scoreText = GetComponent<TextMeshProUGUI>();
        scoreText = GameObject.FindWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
        scoreText.SetText("Scrap: 0");
        //highScore = PlayerPrefs.GetFloat("HighScore", 0);
 
        scoreText.ForceMeshUpdate(true);
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Debug.Log("player object found");
            playerHealthScript = player.GetComponent<SCR_PlayerHealth>();
        }
        else
        {
            Debug.Log("player object not found");
        }

        downedText = GameObject.FindWithTag("DownedText").GetComponent<TextMeshProUGUI>();
        downedText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       highScoreText.SetText("High Score: " + PlayerPrefs.GetFloat("HighScore", 0));

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Open New Scene");
            SceneManager.LoadScene("UpgradeShop");
        }
        else if(Input.GetKeyDown(KeyCode.RightControl))
        {
            PlayerPrefs.DeleteKey("HighScore");
            Debug.Log("High Score Reset");
        }

        if(player != null)
        {
            if(playerHealthScript.curHealth <=0 && playerDeath == false)
            {
                playerDeathSFX.Play();
                playerDeath = true;
                playerDeathFX.SetActive(true);
            }
        }


    }

    public void UpdateTotalPoints(float points)
    {
        totalPoints += points;
        Debug.Log("Score " + totalPoints);
        scoreText.SetText("Scrap: " + totalPoints.ToString());

        if(totalPoints > PlayerPrefs.GetFloat("HighScore",0))
        {
            Debug.Log("New High Score");
            PlayerPrefs.SetFloat("HighScore", totalPoints);
            highScoreText.SetText("High Score: " + totalPoints); 

        }
    }
    //Call this went subtracting from store points. enter a negative number to subtract.
    public void UpdateStorePoints(float points)
    {
        storePoints += points;
    }
}
