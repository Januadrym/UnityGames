using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Move : MonoBehaviour
{
    public float speed;
    public GameObject explosion;
    public TextMeshProUGUI livesCount;
    const int maxLives = 2;
    int lives;
    public GameObject GameManager;


    public void Start()
    {
        lives = maxLives;
        livesCount.text = lives.ToString();
    }
    void FixedUpdate()
    {
        // get input from keyboard or anything
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(h, v);
        GetComponent<Rigidbody2D>().velocity = direction * speed;

        GetComponent<Animator>().SetFloat("direction", h); 

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyShip" || collision.gameObject.tag == "EnemyBullet")
        {
            GetComponent<AudioSource>().Play();
            playExplosion();
            lives--;
            livesCount.text = lives.ToString();

            Destroy(collision.gameObject); //destroy enemy
            if (lives == 0)
            {
                //destroy player
                Destroy(gameObject);

                GameManager.GetComponent<GameManager>().SetGameManagerState(global::GameManager.GameManagerState.Gameover);
            }            
        }    
        

    }
    void playExplosion()
    {
        GameObject explode = (GameObject)Instantiate(explosion);
        explode.transform.position = transform.position;
    }
}
