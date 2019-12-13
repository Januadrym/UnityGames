using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public AudioSource gameOverMusic;
    void Start()
    {
        StartCoroutine(GameOverScene());
    }

    IEnumerator GameOverScene()
    {
        gameOverMusic.Play();
        yield return new WaitForSecondsRealtime(4f);
        SceneManager.LoadScene("Mario-1-1");
    }
}
