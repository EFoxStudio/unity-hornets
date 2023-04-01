using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerControllerLobby : MonoBehaviour
{
    Rigidbody2D body;

    public GameObject canvas;

    float horizontal;
    float vertical;
    bool startGame = true;
    public Animator animator;
    private bool m_FacingRight = true;

    public float runSpeed = 5.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void Stop()
    {
        body.velocity = Vector3.zero;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(horizontal*runSpeed));

        vertical = Input.GetAxisRaw("Vertical");

        if(horizontal < 0 && !m_FacingRight)
		{
			// ... flip the player.
			Flip();
		}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (horizontal > 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);

        if(vertical > 0){
            animator.SetBool("isUp", true);
        }else{
            animator.SetBool("isUp", false);
        }
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
