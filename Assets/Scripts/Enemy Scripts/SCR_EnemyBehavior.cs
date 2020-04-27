using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateStuff;

[System.Serializable]
    public class WanderBoundry
    {
        public float xMin, xMax, zMin, zMax;
    }

public class SCR_EnemyBehavior : MonoBehaviour
{
    public WanderBoundry wanderLimit;
    public float FieldOfViewAngle = 110f;
    public bool isPlayerSpotted;
    public GameObject player;
    public float maxDistance;
    public float moveSpeed = 4;
    public float wanderTime;
    public float MaxWanderTime;

    //public SCR_StateMachine<SCR_EnemyBehavior> stateMachine { get; set; }

    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        isPlayerSpotted = false;

    }

    // Update is called once per frame
    void Update()
    {

        Wander();
        if(isPlayerSpotted == true)
        {
            transform.LookAt(player.transform.position);
            transform.position += transform.forward * moveSpeed;
        }

    }
    public void Wander()
    {
        if (wanderTime > 0)
        {
            transform.Translate(Vector3.forward * moveSpeed);
            wanderTime -= Time.deltaTime;
        }
        else
        {
            StartCoroutine(MovementPause());
            wanderTime = Random.Range(1, MaxWanderTime);
            transform.eulerAngles = new Vector3(0, Random.Range(-360, 360), 0);
        }

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, wanderLimit.xMin, wanderLimit.xMax),
            4.0f,
            Mathf.Clamp(transform.position.z, wanderLimit.zMin, wanderLimit.zMax));

        Debug.Log("Turning...");
        Vector3 direction = player.transform.position - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);

        if (angle < FieldOfViewAngle * .5f)
        {
            //Debug.Log("Angle test");
            if(Physics.Raycast(transform.position, direction, out hit, maxDistance))
            {
                Debug.Log("SPOOOOOOTTED");
                isPlayerSpotted = true;
            }
        }
    }
    IEnumerator MovementPause()
    {
        yield return new WaitForSeconds(1f);
    }
    void Chase()
    {
        transform.LookAt(player.transform.position);
        transform.position += transform.forward * moveSpeed;
    }
}

