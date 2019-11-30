using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject ship;
    // Start is called before the first frame update
    void Start()
    {
        float interval = Random.Range(1, 10);
        InvokeRepeating("SpawnNext", interval, interval);
    }

    void SpawnNext()
    {
        Instantiate(ship, transform.position, Quaternion.identity);
    }
}
