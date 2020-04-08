using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PlayerCameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(mouseRay,out rayLength))
        {
            Vector3 playerAimPoint = mouseRay.GetPoint(rayLength);
            Debug.DrawLine(mouseRay.origin,playerAimPoint,Color.green);

            transform.LookAt(new Vector3(playerAimPoint.x,transform.position.y,playerAimPoint.z));
        }
    }
}
