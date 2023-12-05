using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyDamageCalculation : MonoBehaviour
{
    EnemyStatus stats;
    [SerializeField] TextMeshProUGUI damageOutputDisplay;

    private void Awake()
    {
        stats = gameObject.GetComponent<EnemyStatus>();
        damageOutputDisplay = GameObject.FindGameObjectWithTag("DamageOutput").GetComponent<TextMeshProUGUI>();
    }

    public void TakeDamage(int min, int max)
    {
        int damageTaken = Random.Range(min,max);
        stats.ReceiveDamage(damageTaken);
        damageOutputDisplay.text = "Damage Dealt: " + damageTaken;
    }
}
