using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class PlayerControler : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    bool isGrounded = true;
    public Transform GroundCheck1;
    public LayerMask groundLayer;


    private void Start()
    {
        
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(h*speed, rb.velocity.y);
        rb.velocity = movement;

        isGrounded = Physics2D.OverlapCircle(GroundCheck1.position, 0.05f, groundLayer);

        if (Input.GetButtonDown("Jump"))
            if (isGrounded)
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);

   

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }



}
