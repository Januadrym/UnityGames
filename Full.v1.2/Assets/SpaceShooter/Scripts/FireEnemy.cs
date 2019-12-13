using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemy : MonoBehaviour
{
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        float interval = Random.Range(1f, 15f);
        InvokeRepeating("Fire", interval, interval);
    }

    void Fire()
    {
        GameObject g = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
        Physics2D.IgnoreCollision(g.GetComponent<Collider2D>(), transform.parent.GetComponent<Collider2D>());
    }

}
