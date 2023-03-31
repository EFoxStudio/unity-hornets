using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float moveSpeed = 1.0f; 
    private Rigidbody2D rb; 
    private Vector2 moveDirection; 
    private TrailRenderer trail; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trail = GetComponent<TrailRenderer>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (horizontalInput != 0 && moveDirection.y == 0)
        {
            moveDirection = new Vector2(horizontalInput, 0);
            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }
        else if (verticalInput != 0 && moveDirection.x == 0)
        {
            moveDirection = new Vector2(0, verticalInput);
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trail"))
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TrailEnd"))
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}


