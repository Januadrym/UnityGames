using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject GameOver;
    public GameObject scoreTextUI;
    public enum GameManagerState
    {
        Opening,
        Gameover,
    }

    GameManagerState GMState;
    // Start is called before the first frame update
    void Start()
    {
        GMState = GameManagerState.Opening;
    }

    void UpdateGameManagerState()
    {
        switch(GMState)
        {
            case GameManagerState.Opening:
                GameOver.SetActive(false);                
                break;

            case GameManagerState.Gameover:
                ////display game over text
                GameOver.SetActive(true);

                ////restart game
                Invoke("ReloadScene", 5f);
                break;
        }
    }

    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        scoreTextUI.GetComponent<GameScore>().Score = 0;
    }
}
