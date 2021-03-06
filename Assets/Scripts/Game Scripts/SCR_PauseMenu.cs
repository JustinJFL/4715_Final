﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SCR_PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    void Start()
    {
        //pauseMenuUI.SetActive(false);
        //GameIsPaused = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            if(GameIsPaused == false)
            {
                //GameIsPaused = true;
                Pause();
            }
            else
            {
                //GameIsPaused = false;
                Resume();
            }
        }
    }
    public void Resume()
    {
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("Resumed. Game is Paused: " + GameIsPaused);
    }

    public void Pause()
    {
        GameIsPaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Paused. Game is paused: " + GameIsPaused);
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu...");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        GameIsPaused=false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu",LoadSceneMode.Single);

    }
}