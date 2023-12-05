using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    // Component Variables
    private Rigidbody2D rb;
    private Animator animator;

    // Public Variables
    [HideInInspector] public bool playerTurned; // Hidden since it should only be used by another script(s)

    // Private / [SerializeField] Variables
    [SerializeField] float movementPower = 10f;
    [SerializeField] float jumpPower = 10f;
    float inputH;
    float jump = 0;

    //const Variables
    const float MAXJUMP = 2; // Hard limit on max jumps


    //-------------------------------------------------------------------\\
    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement(); // Functionality of player's movement

        if (rb.velocity.y > 3f) // Animation logic for jumping
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isFalling", false);
            animator.SetBool("isIdle", false);
        }
        if (rb.velocity.y < -3f) // Animation logic for falling
        {
            animator.SetBool("isFalling", true);
            animator.SetBool("isJumping", false);
            animator.SetBool("isIdle", false);
        }

        if (rb.velocity.y == 0) 
        {
            jump = 0; // Resets player's jumps to 0 after retaining a 0 velocity on the y-axis
            if (animator.GetBool("isJumping") == true || animator.GetBool("isFalling")) // Animation logic for reverting from jumping/falling
            {
                animator.SetBool("isJumping", false);
                animator.SetBool("isFalling", false);
                animator.SetBool("isIdle", true);
            }
        }
    }

    void Movement()
    {
        inputH = Input.GetAxisRaw("Horizontal");    // Get input from A/D keys

        Vector2 movement = inputH * movementPower * Time.deltaTime * Vector2.right; // Calculate the movement for the player

        // Logic for running and idle
        if (inputH != 0 && rb.velocity.y < 3f && rb.velocity.y > -3f) // Animation logic for moving left/right
        {
            animator.SetBool("isMoving", true);
            
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        if (Input.GetButtonDown("Jump") && jump != MAXJUMP) // Reads jump input and limits the player's jump to only allow it when not exceeding the max jump limit
        {
            rb.velocity = Vector2.up * jumpPower;   //Adds vertical force to the player
            ++jump;
        }

        
        if (inputH == -1) // Faces the player in the direction they're moving in
        { 
            transform.localScale = new (-1, 1, 1);
            playerTurned = true;
        }
        else if (inputH == 1)
        {
            transform.localScale = new(1, 1, 1);
            playerTurned = false;
        }

        
        if (rb.velocity.x <= movementPower && rb.velocity.x >= -movementPower) // Limits the player's velocity in both directions
        {
            rb.AddForce(movement * 20, ForceMode2D.Impulse); // Adds horizontal force to the player
        }

        
        if (inputH == 0 && rb.velocity.x != 0) // Once the player stops pressing A or D, they will come to a immediate stop
        {
            float yVelocity = rb.velocity.y;
            rb.velocity = Vector2.right * 0;        
            rb.velocity = Vector2.up*yVelocity; // Preserving the velocity of y to allow for natural and responsive control in mid-air
        }
    }

    
}
