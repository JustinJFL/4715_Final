using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_Tutorial_Menus : MonoBehaviour
{

    public GameObject[] popUps;
    private int popUpIndex;

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



    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Pop up index is: " + popUpIndex);
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
            if (Input.GetAxis("Horizontal") > .5 
            || Input.GetAxis("Horizontal") <= -.5 
            || Input.GetAxis("Vertical") > 11 
            || Input.GetAxis("Vertical") <= -1)
            {

                popUpIndex++;

            }
        }

        if (popUpIndex == 1)
        {
            Debug.Log("You have hit 1 on popup index");

            if(Input.GetButton("Attack"))
            {
                Debug.Log("this worked somehow");

                popUpIndex++;
            }
        }


        if (popUpIndex >= 2)
        {
           // Cursor.visible = true;
        }
    }

    public void PopUpCounter()
    {
        popUpIndex++;
    }


    }
    



