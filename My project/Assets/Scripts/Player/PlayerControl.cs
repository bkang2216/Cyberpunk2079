using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;

    public float movementSpeed = 5f;

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
        Vector2 movement = new Vector2 ( Time.deltaTime * movementSpeed * inputH, 0);
        rb.MovePosition(movement);
    }
}
