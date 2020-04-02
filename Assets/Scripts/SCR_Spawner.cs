using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Spawner : MonoBehaviour
{
    public SCR_PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime;
    public Transform[] spawnPoints; // Place down empty gameObjects to set spawnpoints.
    public int spawnLimit; // Max number of enemies that should spawn.
    public int enemyCount; // Count of the number of enemies spawned

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        if (playerHealth.curHealth <= 0 || enemyCount >= spawnLimit) // Is there a condition for when the area is "cleared"?
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        enemyCount += 1;

        Debug.Log("Enemies Spawned: " + enemyCount);
    }
}
