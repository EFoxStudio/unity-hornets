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
    public Animator animator;
    bool isGrounded = true;
    public Transform GroundCheck1;
    public LayerMask groundLayer;


    private void Start()
    {
        
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal") * speed;

        animator.SetFloat("Speed", Mathf.Abs(h));

        Vector2 movement = new Vector2(h, rb.velocity.y);
        rb.velocity = movement;

        isGrounded = Physics2D.OverlapCircle(GroundCheck1.position, 0.05f, groundLayer);
        animator.SetBool("isJump", !isGrounded);

        if (Input.GetButtonDown("Jump"))
            if (isGrounded)
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);

   

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }



}
