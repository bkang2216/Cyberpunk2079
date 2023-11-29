using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rules : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        Physics2D.IgnoreLayerCollision(3,3);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
    }
}
