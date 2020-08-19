using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerA, PlayerB;
    private Vector3 PlayerAStartPos, PlayerBStartPos;
    public float RestartTime = 0.2f;

    private void Start()
    {
        PlayerAStartPos = PlayerA.transform.position;
        PlayerBStartPos = PlayerB.transform.position;
    }

    public void RestartLevel()
    {
        StartCoroutine("RestartCurrentLevel");
    }
    public IEnumerator RestartCurrentLevel()
    {
        /*PlayerA.gameObject.SetActive(false);
        PlayerA.gameObject.SetActive(false);
        yield return new WaitForSeconds(RestartTime);
        PlayerA.transform.position = PlayerAStartPos;
        PlayerB.transform.position = PlayerBStartPos;
        PlayerA.gameObject.SetActive(true);
        PlayerA.gameObject.SetActive(true);*/
        yield return new WaitForSeconds(RestartTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
