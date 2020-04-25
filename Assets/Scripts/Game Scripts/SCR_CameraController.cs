using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_CameraController : MonoBehaviour
{
    public Transform playerTrans;
    public float smooth = .5f;
    private Vector3 playerCameraOffset;
    float zoomSpeed = 2f;

    public bool screenshakeBool;

    // Start is called before the first frame update
    void Start()
    {
        playerTrans = GameObject.FindWithTag("Player").GetComponent<Transform>();
        screenshakeBool = this.gameObject.GetComponent<Animator>().GetBool("Screenshake");
        playerCameraOffset = transform.position - playerTrans.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPos = playerTrans.position + playerCameraOffset;
        transform.position = Vector3.Slerp(transform.position,newPos,smooth);
    }

    void Update()
    {
        this.gameObject.GetComponent<Animator>().SetBool("Screenshake",screenshakeBool);
    }

}
