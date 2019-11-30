using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public GameObject explosion;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyShip")
        {
            playExplosion();
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }

    void playExplosion()
    {
        GameObject explode = (GameObject)Instantiate(explosion);
        explode.transform.position = transform.position;
    }
}
