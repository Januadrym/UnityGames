using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlayer : MonoBehaviour
{
    public GameObject bullet;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<AudioSource>().Play();
            GameObject g = (GameObject) Instantiate(bullet, transform.position, Quaternion.identity);
            Physics2D.IgnoreCollision(g.GetComponent<Collider2D>(), transform.parent.GetComponent<Collider2D>());
        }
    }
}
