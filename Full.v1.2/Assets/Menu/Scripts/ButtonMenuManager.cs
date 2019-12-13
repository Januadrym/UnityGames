using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenuManager : MonoBehaviour
{
  public void changescenes(string scenes)
    {
        SceneManager.LoadScene(scenes);
    }
}
