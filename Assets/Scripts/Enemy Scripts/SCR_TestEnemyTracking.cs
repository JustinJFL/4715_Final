using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_TestEnemyTracking : MonoBehaviour
{
    public float speed;
    public SCR_PlayerController player;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = FindObjectOfType<SCR_PlayerController>();
    }

    private void FixedUpdate()
    {
        rb.velocity = (transform.forward * speed);
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
    }
}
