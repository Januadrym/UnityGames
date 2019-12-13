using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemyship;
    public float spawnRate;
    void Start()
    {
        float interval = Random.Range(1, 10) * spawnRate; 
        InvokeRepeating("SpawnNext", interval, interval * spawnRate);  
    }

    void SpawnNext()
    {
        Instantiate(enemyship, transform.position, Quaternion.identity);
    }

}
