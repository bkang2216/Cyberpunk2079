using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatus : MonoBehaviour
{
    public int totalHealth,damage;
    private int healthRemaining;

    private void Awake() 
    {
        healthRemaining = totalHealth;
        Debug.Log(gameObject.name + " health: " + healthRemaining + "/" + totalHealth);
    }
    
    public void ReceiveDamage(int damage)
    {
        healthRemaining -= damage;
        Debug.Log(damage + " damage dealt!" + '\n' + gameObject.name + " health: " + healthRemaining + "/" + totalHealth);
        if (healthRemaining <= 0)
        {
            //Enemy's death animation is played
            Destroy(gameObject);
            Debug.Log(gameObject.name + " was slain.");
        }

    }
}
