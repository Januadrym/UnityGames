using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class openingScript : MonoBehaviour
{
    public void ButtonPlay()
    {
        SceneManager.LoadScene("Mario-1-1");
    }

    public void toMainButton()
    {
        SceneManager.LoadScene("Menu 3D");
    }
}

