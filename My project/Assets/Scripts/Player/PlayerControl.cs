using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    public float movementPower = 10f;
    public float jumpPower = 10f;

    public bool playerTurned;

    float inputH;
    float jump = 0;

    const float MAXJUMP = 2;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();

        if (rb.velocity.y == 0) 
        {
            jump = 0;                               // Resets player's jumps to 0 after retaining a 0 velocity on the y-axis
            if (animator.GetBool("isJumping") == true)
            {
                animator.SetBool("isJumping", false);
                animator.SetBool("isIdle", true);
            }
        }
    }

    void Movement()
    {
        inputH = Input.GetAxisRaw("Horizontal");    // Get input from A/D keys

        Vector2 movement = inputH * movementPower * Time.deltaTime * Vector2.right; // Calculate the movement for the player

        // Logic for running and idle
        if (inputH != 0)
        {
            animator.SetBool("isMoving", true);         // Plays running animation
            
        }
        else
        {
            animator.SetBool("isMoving", false);    // Plays idle animation
        }

        // Reads jump input and limits the player's jump to only allow it when not exceeding the max jump limit
        if (Input.GetButtonDown("Jump") && jump != MAXJUMP)
        {
            rb.velocity = Vector2.up * jumpPower;   //Adds vertical force to the player
            animator.SetBool("isIdle", false);
            animator.SetBool("isJumping", true);    //Plays jumping animation
            ++jump;
        }

        // Faces the player in the direction they're moving in
        if (inputH == -1)
        { 
            transform.localScale = new (-1, 1, 1);
            playerTurned = true;
        }
        else if (inputH == 1)
        {
            transform.localScale = new(1, 1, 1);
            playerTurned = false;
        }

        // Limits the player's velocity in both directions
        if (rb.velocity.x <= movementPower && rb.velocity.x >= -movementPower)
        {
            rb.AddForce(movement * 20, ForceMode2D.Impulse); // Adds horizontal force to the player
        }

        // Once the player stops pressing A or D, they will come to a immediate stop
        if (inputH == 0 && rb.velocity.x != 0)
        {
            float yVelocity = rb.velocity.y;
            rb.velocity = Vector2.right * 0;        // Puts the player's velocity to 0
            rb.velocity = Vector2.up*yVelocity;
        }
    }

    
}
