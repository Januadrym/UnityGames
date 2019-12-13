using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningScript : MonoBehaviour
{
    public void ButtonPlay()
    {
        SceneManager.LoadScene("Space1");
    }

    public void ButtonBackToMain()
    {
        SceneManager.LoadScene("Menu 3D");
    }
}
