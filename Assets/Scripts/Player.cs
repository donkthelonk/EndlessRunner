using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] float jumpForce = 5;
    [SerializeField] Transform raycastOrigin;
    [SerializeField] bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        CheckForInput();
        CheckForGrounded();
    }
    
    // Logic for user input
    void CheckForInput()
    {
        if(isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
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

            }
            else
            {
                isGrounded = false;
            }

            // Send name of object to console
            Debug.Log(hit.transform.name);

            // Draw the ray under the player
            Debug.DrawRay(raycastOrigin.position, Vector2.down, Color.green);
        }
    }
}
