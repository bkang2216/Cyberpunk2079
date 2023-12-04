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
<<<<<<< Updated upstream
    private GameObject player;

    [SerializeField] TextMeshPro healthDisplay;
=======
<<<<<<< HEAD
    public AudioSource DamageSound;
    public AudioSource DeadSound;

=======
    private GameObject player;

    [SerializeField] TextMeshPro healthDisplay;
>>>>>>> d39539cb9b40434b76138a9c03dc06f226e247b6
>>>>>>> Stashed changes

    private void Awake() 
    {
        DamageSound = GetComponent<AudioSource>();
        DeadSound = GetComponent<AudioSource>();
        healthRemaining = totalHealth;
        Debug.Log(gameObject.name + " health: " + healthRemaining + "/" + totalHealth);
        healthDisplay.text = healthRemaining + " / " + totalHealth;
    }
    
    public void ReceiveDamage(int damage)
    {
        player = GetComponent<EnemyBehavior>().player;
        healthRemaining -= damage;
        
        Debug.Log(damage + " damage dealt!" + '\n' + gameObject.name + " health: " + healthRemaining + "/" + totalHealth);
<<<<<<< Updated upstream
        
        
        if (healthRemaining <= 0)
        {
=======
<<<<<<< HEAD
        DamageSound.Play();

        if (healthRemaining <= 0)
        {
            AudioSource.PlayClipAtPoint(DeadSound.clip, transform.position);
            //Enemy's death animation is played
=======
        
        
        if (healthRemaining <= 0)
        {
>>>>>>> d39539cb9b40434b76138a9c03dc06f226e247b6
>>>>>>> Stashed changes
            Destroy(gameObject);
            Debug.Log(gameObject.name + " was slain.");
           

        }
        else
        {
            healthDisplay.text = healthRemaining + " / " + totalHealth;
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
<<<<<<< Updated upstream
=======
    }

    IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
>>>>>>> Stashed changes
    }
}
