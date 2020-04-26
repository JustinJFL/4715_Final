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
}
