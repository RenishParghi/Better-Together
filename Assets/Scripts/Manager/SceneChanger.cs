using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string NextLevel;
    private bool allowPlayer1, allowPlayer2 = false;
    [SerializeField]
    private float NextLevelLoadTime;

    private void OnTriggerEnter2D(Collider2D otherthing)
    {
        if (otherthing.gameObject.tag == "Player1" )
        {
            allowPlayer1 = true;
        }
        if (otherthing.gameObject.tag == "Player2")
        {
            allowPlayer2 = true;
        }

        if (allowPlayer1 && allowPlayer2)
        {
            StartCoroutine(LoadNextScene());
        }
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(NextLevelLoadTime);
        SceneManager.LoadScene(NextLevel);
    }
}
