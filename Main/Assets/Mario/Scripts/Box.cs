using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public AnimationCurve curve;
    float t = 0;
    public GameObject spawnPrefab;
    public GameObject nextPrefab;
    void Update()
    {
        if (t < curve.keys[curve.length - 1].time)
        {
            t += Time.deltaTime;
        }
    }
    IEnumerator sample()
    {
        // start position
        Vector2 pos = transform.position;

        // go through curve time
        for (float t = 0; t < curve.keys[curve.length - 1].time; t += Time.deltaTime)
        {
            // move a bit
            transform.position = new Vector2(pos.x, pos.y + curve.Evaluate(t));

            // come back next Update
            yield return null;
        }
        if (spawnPrefab)
        {
            Instantiate(spawnPrefab, transform.position + Vector3.up, Quaternion.identity);
        }
        if (nextPrefab)
        {
            Instantiate(nextPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // collision below?
        if (coll.contacts[0].point.y < transform.position.y)
        {
            StartCoroutine("sample");
        }
    }
}
