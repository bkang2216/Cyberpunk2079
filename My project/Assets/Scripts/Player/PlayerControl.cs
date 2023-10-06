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
        inputH = Input.GetAxisRaw("Horizontal");
        inputJump = Input.GetAxisRaw("Jump");

        Vector2 movement = inputH * movementPower * Time.deltaTime * Vector2.right;


        if (rb.velocity.x <= movementPower && rb.velocity.x >= -movementPower)
        {
            rb.AddForce(movement, ForceMode2D.Impulse);
        }
        

        if (inputJump == 1 && rb.velocity.y == 0)
        {
            rb.velocity = Vector2.up * jumpPower;
        }

        if (inputH == 0 && rb.velocity.x != 0 && rb.velocity.y == 0)
        {
            rb.velocity = Vector2.right * 0;
        }

        Debug.Log(rb.velocity.x);
    }

}
