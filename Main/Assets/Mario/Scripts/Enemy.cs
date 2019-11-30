using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    // Movement Speed
    public float speed = 2;

    // Current movement Direction
    Vector2 dir = Vector2.right;

    // Upwards push force
    public float upForce = 500;

    void FixedUpdate()
    {
        // Set the Velocity
        GetComponent<Rigidbody2D>().velocity = dir * speed;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        // Hit a destination? Then move into other direction
        transform.localScale = new Vector2(-1 * transform.localScale.x, transform.localScale.y);

        // And mirror it
        dir = new Vector2(-1 * dir.x, dir.y);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // Collided with Mario?
        if (coll.gameObject.name == "Mario")
        {
            // Is the collision above?
            if (coll.contacts[0].point.y > transform.position.y)
            {
                speed = 0;
                // Play Animation
                GetComponent<Animator>().SetTrigger("died");

                // Disable collider so it falls downwards
                // furthur upgrade: layer - to look like the original game
                GetComponent<Collider2D>().enabled = false;

                // Push Mario upwards
                coll.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * upForce);
                
                // Die in a few seconds
                Invoke("Die", 2);
            }
            else 
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
