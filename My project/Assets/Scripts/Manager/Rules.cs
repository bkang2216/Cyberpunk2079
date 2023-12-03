using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rules : MonoBehaviour
{
    [SerializeField] float timeRatePercentage = 100;
    bool gameOver;


    private void Awake()
    {
        GetComponent<SpriteRenderer>().enabled = false; 
        Physics2D.IgnoreLayerCollision(3,3);
        Physics2D.IgnoreLayerCollision(9, 9);
    }

    public void GameOver()
    {
        gameOver = true;
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (!gameOver)
        {
            Time.timeScale = timeRatePercentage / 100;
        }
    }
}
