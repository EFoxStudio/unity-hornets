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
    bool isRoofed = true;
    public Transform GroundCheck1;
    public Transform roofCheck1;
    public LayerMask groundLayer;




    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(h*speed, rb.velocity.y);
        rb.velocity = movement;

        isGrounded = Physics2D.OverlapCircle(GroundCheck1.position, 0.05f, groundLayer);
        isRoofed = Physics2D.OverlapCircle(roofCheck1.position, 0.05f, groundLayer);

        if (isRoofed && isGrounded)
            SceneManager.LoadScene("GameOver");

        if (Input.GetButtonDown("Jump"))
            if (isGrounded)
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        

    }



}
