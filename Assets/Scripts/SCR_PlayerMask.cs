using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PlayerMask : MonoBehaviour
{
    public GameObject camera;
    public GameObject target;
    public LayerMask PlayerMask;

    void Update()
    {
        //RaycastHit hit;

        //Does the raycast intersect Sphere?
        //if (Physics.Raycast(camera.transform.position,
            //(target.transform.position - camera.transform.position).normalized,
            //out hit, Mathf.Infinity, PlayerMask))

            //if it collides with the sphere, scale it to 0
            //if (hit.collider.gameObject.tag == "spheremask")
            //{
                //target.transform.Scale(0, 2);
            //}
            //if it does not collide, scale it to 5
           // else
            //{
            //    target.transform.Scale(5, 2);
            //}
    }

}