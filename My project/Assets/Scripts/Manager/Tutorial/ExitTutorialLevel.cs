using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitTutorialLevel : MonoBehaviour
{
    public GameObject levelCompletionScreen;
    GameObject gameManager;

    private void Awake()
    {
        levelCompletionScreen.SetActive(false);
        gameManager = GameObject.FindGameObjectWithTag("Manager");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0;
            gameManager.GetComponent<Rules>().paused = true;
            levelCompletionScreen.SetActive(true);
        }
    }
}
