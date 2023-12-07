using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rules : MonoBehaviour
{
    [SerializeField] float timeRatePercentage = 100;
    [SerializeField] GameObject GameOverScreen;
    [HideInInspector] public bool paused;
    

    private void Awake()
    {
        GetComponent<SpriteRenderer>().enabled = false; 
        Physics2D.IgnoreLayerCollision(3,3);
        Physics2D.IgnoreLayerCollision(9, 9);
    }

    public void GameOver()
    {
        paused = true;
        GameOverScreen.SetActive(true);
    }

    private void Update()
    {
        if (!paused)
        {
            Time.timeScale = timeRatePercentage / 100;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}
