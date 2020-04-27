using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class SCR_ClockScript : MonoBehaviour 
{

    private Text clockText;
    private int hour;
    private int minute;
    void Awake ()
    {
        clockText = GetComponent<Text>();
    }

    void Update ()
    {
        DateTime time = DateTime.Now;


        if (time.Hour >= 12 && time.Minute >=00)
        {
        hour = time.Hour - 12;
            if(minute<10)
            {
                minute = time.Minute;
                clockText.text = hour + ":0" + minute + " PM";
            }
            else
            {
                minute = time.Minute;
                clockText.text = hour + ":" + minute + " PM";
            }


        }
        else if (time.Hour < 12)
        {
            if(time.Hour == 0)
            {
                hour = time.Hour + 12;
            }
            else
            {
                hour = time.Hour;        
            }
            if(minute <10)
            {
                minute = time.Minute;
                clockText.text = hour + ":0" + minute + " AM";
            }
            else
            {
                minute = time.Minute;
                clockText.text = hour + ":" + minute + " AM";
            }

        }
        
    }

    string LeadingZero (int n)
    {
        return n.ToString().PadLeft(2, '0');
    }
}