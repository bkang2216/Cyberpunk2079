using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject player;
    bool playerTurned;
    
    public int projectileType;
    public float projectileSpeed;
    public float lifespanDuration;
    
    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        player = GameObject.Find("Player");
        playerTurned = player.GetComponent<PlayerControl>().playerTurned;
        StartCoroutine(nameof(Lifespan));
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

    private IEnumerator Lifespan()
    {
        Debug.Log("Bullet Spawn");
        yield return new WaitForSeconds(lifespanDuration);
        Destroy(gameObject);
        Debug.Log("Bullet Deleted");
    }
}
