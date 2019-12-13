using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish : MonoBehaviour
{
    public GameObject princessNotHere;
    public GameObject tryFuther;

    void Start()
    {
        StartCoroutine(DisplayMess());
    }

    IEnumerator DisplayMess()
    {
        yield return new WaitForSecondsRealtime(1f);
        princessNotHere.SetActive(true);
        yield return new WaitForSecondsRealtime(2f);
        tryFuther.SetActive(true);

        //audio 
        yield return new WaitForSecondsRealtime(3f);

        SceneManager.LoadScene("OpeningMario");
    }
}
