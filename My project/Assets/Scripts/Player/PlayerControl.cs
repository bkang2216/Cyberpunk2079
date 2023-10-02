using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;

    public float movementSpeed = 5f;
    public float jumpHeight = 10f;

    float inputH;
    float inputV;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Jump");
        Vector2 movement = new(Time.deltaTime * movementSpeed * inputH, 0);
        Vector2 jump = new(0 , Time.deltaTime * jumpHeight * inputV);
        Debug.Log(inputV);

        rb.MovePosition((Vector2)transform.position + (movement) + (3f * Time.deltaTime * Physics2D.gravity));
        rb.AddForce(jump, ForceMode2D.Impulse);
    }
}
