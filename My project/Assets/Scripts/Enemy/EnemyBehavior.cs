using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public int health;
    int damage;

    private void Awake()
    {
        health = gameObject.GetComponent<EnemyStats>().health;
        damage = gameObject.GetComponent<EnemyStats>().damage;

        Debug.Log(gameObject.name + " | Health/Damage: " + health + "/" + damage);
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
