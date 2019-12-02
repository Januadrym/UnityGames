using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BulletDamage : MonoBehaviour
{
    public GameObject explosion;
    GameObject scoreTextUI;
    void Start()
    {
        scoreTextUI = GameObject.FindGameObjectWithTag("GameScoreTag");
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyShip")
        {            
            playExplosion();
            scoreTextUI.GetComponent<GameScore>().Score += 100;
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
