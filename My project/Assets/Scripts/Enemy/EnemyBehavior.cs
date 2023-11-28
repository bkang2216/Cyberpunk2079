using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    // TODO: ADD ENEMY AI BEHAVIOR, SUCH AS PATHING AND ATTACKING PATTERN
    int damage; //Assigned a value

    public GameObject pointA;
    public GameObject pointB;
    public float speed;

    
    [SerializeField] private Transform currPoint;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;

    void Idle()
    {
        animator.SetBool("isAttacking", false);
    }

    private void Awake()
    {
        damage =    GetComponent<EnemyStatus>().damage;
        rb =            GetComponent<Rigidbody2D>();
        animator =  GetComponent<Animator>();
        sr =            GetComponent<SpriteRenderer>();
        
        currPoint = pointB.transform;

        pointA.transform.SetParent(null);
        pointB.transform.SetParent(null);
    }

    private void Update()
    {
        Patrol();

    }

    void Patrol()
    {
        if (currPoint == pointB.transform)
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(speed, 0);
        }

        if (Vector2.Distance(transform.position, currPoint.position) < 1.5 && currPoint == pointB.transform)
        {
            currPoint = pointA.transform;
            Turn();
        }
        if (Vector2.Distance(transform.position, currPoint.position) < 1.5 && currPoint == pointA.transform)
        {
            currPoint = pointB.transform;
            Turn();
        }
    }

    private void Turn()
    {
        if (sr.flipX == false)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isAttacking", true);
            collision.gameObject.GetComponent<PlayerStatus>().TakeDamage(damage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}
