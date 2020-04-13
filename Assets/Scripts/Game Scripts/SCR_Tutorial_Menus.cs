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
            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A)))
            {
                 popUpIndex++;
               
            }

        }
        if (popUpIndex >= 1)
        {
            if ((Input.GetKeyDown(KeyCode.Mouse0)))
            {
                popUpIndex++;
            }
           
        }


    }
}
