using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_EnemyBehavior : MonoBehaviour
{
    public float FieldOfViewAngle = 110f;
    public bool isPlayerSpotted;
    public GameObject player;
    public float maxDistance;
    public float moveSpeed = 4;

    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        isPlayerSpotted = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);

        if (angle < FieldOfViewAngle * .5f)
        {
            Debug.Log("Angle test");
            if(Physics.Raycast(transform.position, direction, out hit, maxDistance))
            {
                isPlayerSpotted = true;
            }
        }
        //Debug.DrawLine(transform.position, transform.forward);
    }
}

