using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerControllerLobby : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float runSpeed = 5.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enter")
        {
            Debug.Log("Enter");
        }
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "GameOne")
        {
            SceneManager.LoadScene("FirstGame");
        }
        else if (other.gameObject.tag == "GameTwo")
        {
            SceneManager.LoadScene("SecondGame");
        }
        else if (other.gameObject.tag == "GameThree")
        {
            SceneManager.LoadScene("ThirdGame");
        }
        else if (other.gameObject.tag == "GameFour")
        {
            SceneManager.LoadScene("FourthGame");
        }
    }

}
