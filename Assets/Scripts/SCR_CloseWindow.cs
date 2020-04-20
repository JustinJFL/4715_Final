using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_CloseWindow : MonoBehaviour
{
    public GameObject window;
    public void CloseWindow(GameObject window)
    {
        window.SetActive(false);
    }
}
