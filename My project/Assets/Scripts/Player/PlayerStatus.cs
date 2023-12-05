using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
     // Component Variables
    Animator animator;

    // Public Variables
    public AudioSource PlayerHitSound;
    public AudioSource PlayerDeadSound;

    // Private / [SerializeField] Variables
    int health = 10;
    GameObject manager;
    [SerializeField] private Image healthDisplay;
    [SerializeField] private Sprite[] healthSprites;

    //-------------------------------------------------------------------\\
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
        if (collision.gameObject.CompareTag("HealthBoost")) // Heals the player by 1 hp when colliding a health boost pickup and destroys the health boost afterwards
        {
            HealDamage(1);
            Destroy(collision.gameObject);
        }
    }

    private void UpdateDisplay() // Syncs the health bar UI display to the health variable
    {
        if (health >= 0)
        {
            healthDisplay.sprite = healthSprites[health];
        }
    }

    public void TakeDamage(int damage) // A public function for enemies to deal damage to the player and game over code
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

    void HealDamage(int heal) // Healing function
    {
        health += heal;
        if (health > 10)
        {
            health = 10;
        }
        UpdateDisplay();
    }

    void PlayerDeath() // Function for disabling player input scripts and plays death animation
    {
        GetComponent<PlayerControl>().enabled = false;
        GetComponent<PlayerShootingMechanic>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;

        animator.Play("Player_Death");
    }

    void GameOver() // Function for animation event for game over
    {
        Debug.Log("Game Over!");
        manager.GetComponent<Rules>().GameOver();
    }

    void NotHurt() // Function for animation event for recovering from hurt animation
    {
        animator.SetBool("isHurt", false);
    }
}