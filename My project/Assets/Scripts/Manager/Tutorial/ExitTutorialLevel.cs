using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitTutorialLevel : MonoBehaviour
{
    public GameObject levelCompletionScreen;

    private void Awake()
    {
        levelCompletionScreen.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0;
            levelCompletionScreen.SetActive(true);
        }
    }
}
