using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBoss : MonoBehaviour
{
    public GameObject GameManager;
    public GameObject explosion;
    public int hitPoint;
    public Transform[] waysPoints;
    int currentWayPoint = 0;
    public float speed;
    void Update()
    {
        checkHP();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BulletPlayer")
        {
            hitPoint--;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Ship")
        {
            GameManager.GetComponent<GameManager>().SetGameManagerState(global::GameManager.GameManagerState.Gameover);
        }
    }

    void checkHP()
    {
        if(hitPoint == 0)
        {
            playExplosion();
            Destroy(gameObject);
            GameManager.GetComponent<GameManager>().SetGameManagerState(global::GameManager.GameManagerState.youWin);
        } else
        {
            if (transform.position != waysPoints[currentWayPoint].position)
            {
                Vector2 newPos = Vector2.MoveTowards(transform.position, waysPoints[currentWayPoint].position, speed);
                GetComponent<Rigidbody2D>().MovePosition(newPos);
            }
            else currentWayPoint = (currentWayPoint + 1) % waysPoints.Length;
        }
    }
    void playExplosion()
    {
        GameObject explode = (GameObject)Instantiate(explosion);
        explode.transform.position = transform.position;
    }
}
