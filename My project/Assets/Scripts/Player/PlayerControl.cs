using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;

    public float movementPower = 10f;
    public float jumpPower = 10f;

    float inputH;
    float inputJump;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        inputH = Input.GetAxisRaw("Horizontal");    // Get input from A/D keys
        inputJump = Input.GetAxisRaw("Jump");       // Get input from Spacebar key

        Vector2 movement = inputH * movementPower * Time.deltaTime * Vector2.right; // Calculate the movement for the player

        // Limits the player's velocity in both directions
        if (rb.velocity.x <= movementPower && rb.velocity.x >= -movementPower)
        {
            rb.AddForce(movement, ForceMode2D.Impulse); // Adds horizontal force to the player
        }
        
        // Limits the player's jump to only allow it once grounded
        if (inputJump == 1 && rb.velocity.y == 0)
        {
            rb.velocity = Vector2.up * jumpPower;   //Adds vertical force to the player
        }

        // Once the player stops pressing A or D, they will come to a immediate stop
        if (inputH == 0 && rb.velocity.x != 0 && rb.velocity.y == 0)
        {
            rb.velocity = Vector2.right * 0;    // Puts the player's velocity to 0
        }
    }

}
