using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "PlayerShip")
            Destroy(collision.gameObject);
    }
}
