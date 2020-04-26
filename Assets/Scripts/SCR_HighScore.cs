using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SCR_HighScore : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    // Start is called before the first frame update
    void Start()
    {
        highScore.text = PlayerPrefs.GetFloat("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
