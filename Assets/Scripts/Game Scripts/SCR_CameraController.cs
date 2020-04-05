using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_CameraController : MonoBehaviour
{
    public Transform playerTrans;
    public float smooth = .5f;
    private Vector3 playerCameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        playerCameraOffset = transform.position - playerTrans.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPos = playerTrans.position + playerCameraOffset;

        transform.position = Vector3.Slerp(transform.position,newPos,smooth);
    }
}
