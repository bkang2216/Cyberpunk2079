using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    TextMeshProUGUI healthDisplay;

    int healthRemaining;

    public int health;
    public int damage;

    private void Awake()
    {
        healthDisplay = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        healthRemaining = gameObject.GetComponentInChildren<EnemyBehavior>().health;
    }
}
