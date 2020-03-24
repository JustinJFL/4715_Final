using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PickupBehavior : MonoBehaviour
{
    private Rigidbody rb;
    public float spawnForce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Launches pickups upward when instantiated
        rb.AddForce(Vector3.up * spawnForce);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
