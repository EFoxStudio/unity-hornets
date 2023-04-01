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
    bool isRoofed = true;
    public Transform GroundCheck1;
    public Transform roofCheck1;
    private bool m_FacingRight = true;
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
        isRoofed = Physics2D.OverlapCircle(roofCheck1.position, 0.05f, groundLayer);

        if (isRoofed && isGrounded)
            SceneManager.LoadScene("GameOver");

        animator.SetBool("isJump", !isGrounded);

        if (Input.GetButtonDown("Jump"))
            if (isGrounded)
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        if (h < 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (h > 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void Flip()
	{
        m_FacingRight = !m_FacingRight;
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}
