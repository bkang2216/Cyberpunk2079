using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    // WIP Script - Will replace HurtPlayer and PlayerHealth Scripts
    private int health = 10;
    private GameObject manager;

    [SerializeField] private Image healthDisplay;
    [SerializeField] private Sprite[] healthSprites;
    [SerializeField] private Rigidbody2D rb;
    private Animator animator;


    private void Awake()
    {
        UpdateDisplay();
    }

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
        animator = GetComponent<Animator>();
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
        if (health >= 0)
        {
            healthDisplay.sprite = healthSprites[health];
        }
        else
        {
            healthDisplay.sprite = healthSprites[0];
        }
    }

    public void TakeDamage(int damage)
    {
        
        health -= damage;

        UpdateDisplay();
        if (health <= 0)
        {
            PlayerDeath();
        }
        else
        {
            animator.SetBool("isHurt", true);
        }
    }

    void NotHurt()
    {
        animator.SetBool("isHurt", false);
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
        //GetComponent<SpriteRenderer>().enabled = false;

        animator.Play("Player_Death");
        
        GetComponent<Rigidbody2D>().simulated = false;
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        manager.GetComponent<Rules>().GameOver();
    }
}
