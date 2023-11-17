using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    // WIP Script - Will replace HurtPlayer and PlayerHealth Scripts
    private int health = 10;
    [SerializeField] private Image healthDisplay;
    [SerializeField] private Sprite[] healthSprites;

    private void Awake()
    {
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        healthDisplay.sprite = healthSprites[health];
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        UpdateDisplay();
        if (health <= 0)
        {
            // Game Over Function
        }
    }

    public void HealDamage(int heal)
    {
        health += heal;
        if (health > 10)
        {
            health = 10;
        }
        UpdateDisplay();
    }
}
