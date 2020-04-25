using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCR_MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public bool quit = false;
    public bool play = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(play == true)
        {
            Play();
        }
        else if (quit == true)
        {
            Quit();
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("BlockMesh",LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
