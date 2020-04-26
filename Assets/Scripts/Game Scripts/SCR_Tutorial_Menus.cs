using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SCR_Tutorial_Menus : MonoBehaviour
{

    public GameObject[] popUps;
    public int popUpIndex;

    public GameObject movementTutorial;
    public GameObject attackTutorial;
    public GameObject currencyTutorial;
    public GameObject objectiveTutorial;
    public GameObject healthTutorial;



    // Start is called before the first frame update
    void Start()
    {

        //movementTutorial.SetActive(true);
        //attackTutorial.SetActive(false);
        //currencyTutorial.SetActive(false);
        //objectiveTutorial.SetActive(false);
        //healthTutorial.SetActive(false);
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "BlockMesh")
        {
        //Debug.Log("Pop up index is: " + popUpIndex);
        for (int i = 0; i < popUps.Length; i++)
        {


            if(i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }

            else
            {
                popUps[i].SetActive(false);
            }
        }
        
        if (popUpIndex == 0)
        {
            if (Input.GetAxis("Horizontal") > .8 
            || Input.GetAxis("Horizontal") <= -.8 
            || Input.GetAxis("Vertical") > .8 
            || Input.GetAxis("Vertical") <= -.8)
            
            {
                popUpIndex++;
            
            }
        }

        if (popUpIndex == 1)
        {
            if(Input.GetButtonDown("LightAttack"))
            {
                PopUpCounter();
            }
        }

        if (popUpIndex == 2)
        {
            if(Input.GetButtonDown("HeavyAttack"))
            {
                PopUpCounter();
            }
        }

        if(popUpIndex >2)
        {
            if(Input.GetKeyDown(KeyCode.JoystickButton3))
            {
                PopUpCounter();
            }
        }

        if (popUpIndex >=8)
        {
            popUpIndex = 8;
        }
        }

        else
        {
            //Debug.Log("Didn't load tutorial because it's not level 1");
        }

    }

    public void PopUpCounter()
    {
        popUpIndex++;
    }


    }
    



