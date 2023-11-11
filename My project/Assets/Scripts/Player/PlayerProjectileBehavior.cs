using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileBehavior : MonoBehaviour
{
    Rigidbody2D rb;

    public float projectileSpeed;
    GameObject player;

    bool playerTurned;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        player = GameObject.Find("Player");
        playerTurned = player.GetComponent<PlayerControl>().playerTurned;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTurned)
        {
            rb.velocity = projectileSpeed * Time.deltaTime * -transform.right;
        }
        else
        {
            rb.velocity = projectileSpeed * Time.deltaTime * transform.right;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
