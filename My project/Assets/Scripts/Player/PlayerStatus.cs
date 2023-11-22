using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    private int health = 10;
    [SerializeField] private Image healthDisplay;
    [SerializeField] private Sprite[] healthSprites;

    private void Awake()
    {
        UpdateDisplay();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HealthBoost"))
        {
            HealDamage(1);
            Destroy(collision.gameObject);
        }
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
            PlayerDeath();
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

    void PlayerDeath()
    {
        GetComponent<PlayerControl>().enabled = false;
        GetComponent<PlayerShootingMechanic>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
    }
}
