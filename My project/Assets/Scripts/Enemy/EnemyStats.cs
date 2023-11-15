using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    //TextMeshProUGUI healthDisplay;
    [SerializeField] public int health,damage; 

    private void Awake() 
    {
        //healthDisplay = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        //healthRemaining = gameObject.GetComponentInChildren<EnemyBehavior>().health;
    }
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        Debug.Log(gameObject.name + " | Health/Damage: " + health + "/" + damage);

        if (health <= 0)
        {
            //Enemy is Dead
        }
    }
}
