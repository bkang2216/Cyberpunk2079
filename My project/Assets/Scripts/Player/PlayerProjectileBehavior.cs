using System.Collections;
using System.Collections.Generic;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyDamageCalculation>().TakeDamage(projectileDamage[0], projectileDamage[1]);
        }
    }

    private IEnumerator Lifespan()
    {
        yield return new WaitForSeconds(lifespanDuration);
        Destroy(gameObject);
    }
}
