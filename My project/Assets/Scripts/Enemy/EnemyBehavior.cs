using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    int health;
    int damage;

    private void Awake()
    {
        health = GetComponent<EnemyStats>().health;
        damage = GetComponent<EnemyStats>().damage;
    }

    public void TakeDamage()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

        }
    }
}
