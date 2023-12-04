using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatus : MonoBehaviour
{
    public int totalHealth,damage;
    private int healthRemaining;
    private GameObject player;

    [SerializeField] TextMeshPro healthDisplay;

    private void Awake() 
    {
        healthRemaining = totalHealth;
        Debug.Log(gameObject.name + " health: " + healthRemaining + "/" + totalHealth);
        healthDisplay.text = healthRemaining + " / " + totalHealth;
    }
    
    public void ReceiveDamage(int damage)
    {
        player = GetComponent<EnemyBehavior>().player;
        healthRemaining -= damage;
        
        Debug.Log(damage + " damage dealt!" + '\n' + gameObject.name + " health: " + healthRemaining + "/" + totalHealth);
        
        
        if (healthRemaining <= 0)
        {
            Destroy(gameObject);
            Debug.Log(gameObject.name + " was slain.");
        }
        else
        {
            healthDisplay.text = healthRemaining + " / " + totalHealth;
        }

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            GetComponent<EnemyBehavior>().player = player;
        }
    }
}
