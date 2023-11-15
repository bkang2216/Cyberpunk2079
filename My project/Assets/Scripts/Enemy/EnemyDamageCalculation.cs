using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageCalculation : MonoBehaviour
{
    EnemyStatus stats;

    private void Awake()
    {
        stats = gameObject.GetComponent<EnemyStatus>();
    }

    public void TakeDamage(int min, int max)
    {
        int damageTaken = Random.Range(min,max);
        stats.ReceiveDamage(damageTaken);
    }
}
