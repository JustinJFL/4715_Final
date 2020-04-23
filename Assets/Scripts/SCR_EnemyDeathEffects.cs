using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class SCR_EnemyDeathEffects : MonoBehaviour
{
    private GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
        Destroy(gameObject,2.5f);
    }

    // Update is called once per frame
    void Update()
    {
            mainCamera.GetComponent<Animator>().SetBool("Screenshake",true);
    }

}
