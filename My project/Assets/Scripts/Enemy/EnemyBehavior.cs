using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    // TODO: ADD ENEMY AI BEHAVIOR, SUCH AS PATHING AND ATTACKING PATTERN
    int damage;
    private void Awake()
    {
        damage = gameObject.GetComponent<EnemyStatus>().damage;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerStatus>().TakeDamage(damage);
        }
    }
}
