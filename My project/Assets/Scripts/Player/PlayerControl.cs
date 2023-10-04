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

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputH = Input.GetAxisRaw("Horizontal");

        Vector2 movement = inputH * movementPower * Time.deltaTime * Vector2.right;

        rb.AddForce(movement, ForceMode2D.Impulse);

        if (Input.GetButtonDown("Jump") && rb.velocity.y == 0)
        {
            rb.velocity = Vector2.up * jumpPower;
        }

        if (inputH == 0 && rb.velocity.x != 0 && rb.velocity.y == 0)
        {
            rb.velocity = Vector2.right * 0;
        }
    }

}
