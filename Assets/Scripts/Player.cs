using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] float jumpForce = 5;
    [SerializeField] Transform raycastOrigin;
    [SerializeField] Animator anim;
    [SerializeField] bool isGrounded;
    [SerializeField] bool jump;
    float lastYPos;
    public float distanceTraveled;
    [SerializeField] UIController uiController;

    private void Start()
    {
        // initialize player Y position
        lastYPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        distanceTraveled += Time.deltaTime;
        CheckForInput();
        CheckForFalling();
    }

    void FixedUpdate()
    {
        CheckForGrounded();
        CheckForJump();
    }

    // Logic for user input
    void CheckForInput()
    {
        if(isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump = true;

                // Triggers the jump animation
                anim.SetTrigger("Jump");
            }
        }
    }

    // Check if the player is grounded
    void CheckForGrounded()
    {
        // Find out what is beneath the player
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin.position, Vector2.down);

        // hit null check
        if (hit.collider != null)
        {
            if (hit.distance < 0.1f)
            {
                isGrounded = true;
                anim.SetBool("isGrounded", true);
            }

            // Send name of object to console
            //Debug.Log(hit.transform.name);

            // Draw the ray under the player
            Debug.DrawRay(raycastOrigin.position, Vector2.down, Color.green);
        }
        else
        {
            isGrounded = false;
            anim.SetBool("isGrounded", false); ;
        }
    }

    // Jump logic
    void CheckForJump()
    {
        // check if user has pressed jump key; if so, reset jump bool and jump
        if (jump)
        {
            jump = false;
            playerRb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    void CheckForFalling()
    {
        // check if player is falling
        if (transform.position.y < lastYPos)
        {
            anim.SetBool("Falling", true);
        }
        else
        {
            anim.SetBool("Falling", false);
        }

        // store player Y position
        lastYPos = transform.position.y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Obstacle"))
        {
            //Debug.Log("Collide with Obstacle");
            uiController.ShowGameOverScreen();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Collectable"))
        {
            Destroy(collision.gameObject);
        }
    }

}
