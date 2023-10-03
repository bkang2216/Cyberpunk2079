using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 jump;

    public float movementSpeed = 5f;
    public float jumpPower = 10f;

    float inputH;
    float inputV;

    bool initiated;

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
        jump = Vector2.up * jumpPower;

        rb.MovePosition((Vector2)transform.position + (movement) + (2f * Time.deltaTime * Physics2D.gravity));
        
        rb.AddForce(jump, ForceMode2D.Impulse);

        if (!initiated)
        {
            InvokeRepeating(nameof(ReportDebug), 0, 1);
            initiated = true;
        }
        
    }

    void ReportDebug()
    {
        Debug.Log("STATUS: " + jump);
    }
}
