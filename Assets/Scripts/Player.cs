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

    // Update is called once per frame
    void Update()
    {
        CheckForInput();
    }

    void FixedUpdate()
    {
        CheckForGrounded();
        Jump();
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
                anim.SetBool("IsGrounded", true);
            }
            else
            {
                isGrounded = false;
                anim.SetBool("IsGrounded", false); ;
            }

            // Send name of object to console
            Debug.Log(hit.transform.name);

            // Draw the ray under the player
            Debug.DrawRay(raycastOrigin.position, Vector2.down, Color.green);
        }
    }

    // Jump logic
    void Jump()
    {
        // check if user has pressed jump key; if so, reset jump bool and jump
        if (jump)
        {
            jump = false;
            playerRb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}
