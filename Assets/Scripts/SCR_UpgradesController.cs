using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SCR_UpgradesController : MonoBehaviour
{
        public GameObject upgrade1Description;
        public GameObject upgrade1Video;
        public GameObject upgrade2Description;
        public GameObject upgrade2Video;
        public GameObject upgrade3Description;
        public GameObject upgrade3Video;

    public void upgrade1Variables(bool upgrade1)
    {
        if(upgrade1)
        {
            upgrade1Description.SetActive(true);
            upgrade1Video.SetActive(true);
        }
    }

    public void upgrade2Variables(bool upgrade2)
    {
        if(upgrade2)
        {
            upgrade2Description.SetActive(true);
            upgrade2Video.SetActive(true);
        }
    }

    public void upgrade3Variables(bool upgrade3)
    {
        if(upgrade3)
        {
            upgrade3Description.SetActive(true);
            upgrade3Video.SetActive(true);
        }
    }
}
