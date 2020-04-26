using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SCR_DownedObjectController : MonoBehaviour
{
    public float timeToDestroy = 8f;
    private TextMeshProUGUI downedText;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject,timeToDestroy);
        downedText = GameObject.FindWithTag("DownedText").GetComponent<TextMeshProUGUI>();
        StartCoroutine(disableText());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            downedText.enabled = true;
        }
    }
        void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            downedText.enabled = false;
        }
    }

    private IEnumerator disableText()
    {
        yield return new WaitForSeconds(timeToDestroy - .1f);
        downedText.enabled = false;
    }
}
