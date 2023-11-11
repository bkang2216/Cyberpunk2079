using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;

    public GameObject normalProjectile;
    public GameObject projectileOrigin;
    public float movementPower = 10f;
    public float jumpPower = 10f;

    public bool playerTurned;

    float inputH;
    float jump = 0;

    const float MAXJUMP = 2;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shoot();

        if (rb.velocity.y == 0) { jump = 0; } // Resets player's jumps to 0 after retaining a 0 velocity on the y-axis
    }

    void Movement()
    {
        inputH = Input.GetAxisRaw("Horizontal");    // Get input from A/D keys

        Vector2 movement = inputH * movementPower * Time.deltaTime * Vector2.right; // Calculate the movement for the player

        // Limits the player's jump to only allow it when not exceeding the max jump limit
        if (Input.GetButtonDown("Jump") && jump != MAXJUMP)
        {
            rb.velocity = Vector2.up * jumpPower;   //Adds vertical force to the player
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
            rb.AddForce(movement, ForceMode2D.Impulse); // Adds horizontal force to the player
        }

        // Once the player stops pressing A or D, they will come to a immediate stop
        if (inputH == 0 && rb.velocity.x != 0 && rb.velocity.y == 0)
        {
            rb.velocity = Vector2.right * 0;    // Puts the player's velocity to 0
        }
    }

    void Shoot()
    {
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Instantiate(normalProjectile, projectileOrigin.transform.position, transform.rotation);
        }
        
    }
}
