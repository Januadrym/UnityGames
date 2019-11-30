using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 7;
    [Range(0, 1)] public float sliding = 0.5f;

    public float jumpForce = 1000;
    public float upForce = 1000;
    bool isGrounded()
    {
        Bounds bounds = GetComponent<Collider2D>().bounds;
        float range = bounds.size.y * 0.1f;

        Vector2 v = new Vector2(bounds.center.x, bounds.min.y - range);

        RaycastHit2D hit = Physics2D.Linecast(v, bounds.center);

        return (hit.collider.gameObject != gameObject);
    }

    void FixedUpdate()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");

        Vector2 v = GetComponent<Rigidbody2D>().velocity;

        if (horizontalMove != 0)
        {
            // Left/Right
            GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalMove * moveSpeed, v.y);
            transform.localScale = new Vector2(Mathf.Sign(horizontalMove), transform.localScale.y);
        }
        else
        {
            // Slower
            GetComponent<Rigidbody2D>().velocity = new Vector2(v.x * sliding, v.y);
        }
        GetComponent<Animator>().SetFloat("speed", Mathf.Abs(horizontalMove));

        bool grounded = isGrounded();
        if (Input.GetKey(KeyCode.UpArrow) && grounded)
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
        GetComponent<Animator>().SetBool("jumping", !grounded);

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // Collided with enemy
        //if (coll.gameObject.name == "enemyMushroom")
        //{
        //    if (coll.contacts[0].point.y > transform.position.y)
        //    {
        //        GetComponent<Collider2D>().enabled = false;
        //        coll.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * upForce);
        //        moveSpeed = 0;
        //        // Play Animation
        //        GetComponent<Animator>().SetTrigger("death");

        //        Invoke("Die", 2);

        //    }
        //}

        if (coll.gameObject.name == "brick_win")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    //void Die()
    //{
    //    Destroy(gameObject);
    //}
}
