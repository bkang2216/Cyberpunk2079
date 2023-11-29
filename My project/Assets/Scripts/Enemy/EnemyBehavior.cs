using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    int damage; //Assigned a value

    public GameObject pointA;
    public GameObject pointB;
    public float speed;

    
    [SerializeField] private Transform currPoint;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;
    private GameObject player;
    [SerializeField] private bool cooldownTimer;

#pragma warning disable IDE0051 // Remove unused private members
    void Idle() // Used by Skelebot Attack Animation
#pragma warning restore IDE0051 // Remove unused private members
    {
        animator.SetBool("isAttacking", false);
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(0.4f);
        cooldownTimer = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!cooldownTimer)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                cooldownTimer = true;
                animator.SetBool("isAttacking", true);
                collision.gameObject.GetComponent<PlayerStatus>().TakeDamage(damage);
                StartCoroutine(Cooldown());
            }
        }

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
        if (player == null)
        {
            Patrol();
        }
        else
        {
            Hunt();
        }
        

    }

    private void Hunt()
    {

        Vector3 playerPos = transform.InverseTransformPoint(player.transform.position);
        
        if (playerPos.x < 0)
        {
            if (sr.flipX)
            {
                Turn();
            }
            rb.velocity = new Vector2(-speed, 0);
        }
        else
        {
            if (!sr.flipX)
            {
                Turn();
            }
            rb.velocity = new Vector2(speed, 0);
        }

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

        Debug.Log(Vector2.Distance(transform.position, currPoint.position));

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

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.CompareTag("Player"))
        {
            if (player == null)
            {
                player = hit.gameObject;
            }
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}
