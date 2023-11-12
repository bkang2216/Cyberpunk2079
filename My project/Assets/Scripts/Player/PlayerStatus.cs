using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    // WIP Script - Will replace HurtPlayer and PlayerHealth Scripts
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var healthComponent = collision.GetComponent<PlayerHealth>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(10);
            }
        }
    }
}
