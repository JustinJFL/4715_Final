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
        RaycastHit hit;

        //Does the raycast intersect Sphere?
        if (Physics.Raycast(camera.transform.position,
            (target.transform.position - camera.transform.position).normalized,
            out hit, Mathf.Infinity, PlayerMask))

            //if it collides with the sphere, scale it to 0
            if (hit.collider.gameObject.tag == "spheremask")
            {
                target.transform.localScale = new Vector3(0f, 0f, 0f);
            }
            //if it does not collide, scale it to 10
            else
            {
                target.transform.localScale = new Vector3(10f, 10f, 10f);
            }
    }
    }