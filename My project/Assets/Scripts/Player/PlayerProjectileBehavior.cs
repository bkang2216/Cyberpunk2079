using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerProjectileBehavior : MonoBehaviour
{
    GameObject player;
    bool playerTurned;

    public int[] projectileDamage = new int[2];
    public float projectileSpeed;
    public float lifespanDuration;

    private void Start()
    {
        player = GameObject.Find("Player");

        playerTurned = player.GetComponent<PlayerControl>().playerTurned;
        StartCoroutine(nameof(Lifespan));

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();

        if (playerTurned) { transform.localScale *= -1; }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerTurned)
        {
            transform.position = transform.position + projectileSpeed * Time.deltaTime * -transform.right;
        }
        else
        {
            transform.position = transform.position + projectileSpeed * Time.deltaTime * transform.right;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<EnemyDamageCalculation>().TakeDamage(projectileDamage[0], projectileDamage[1]);
        }
    }

    private IEnumerator Lifespan()
    {
        yield return new WaitForSeconds(lifespanDuration);
        Destroy(gameObject);
    }
}
