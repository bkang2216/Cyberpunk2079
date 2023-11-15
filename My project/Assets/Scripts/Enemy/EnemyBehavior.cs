using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    int healthRemaining;
    public int health;
    int damage;
    private void Awake() 
    {
        health = gameObject.GetComponent<EnemyStats>().health;
        damage = gameObject.GetComponent<EnemyStats>().damage;
    }
}
