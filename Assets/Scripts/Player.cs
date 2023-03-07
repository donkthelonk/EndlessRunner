using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] float jumpForce = 5;
    [SerializeField] Transform raycastOrigin;

    // Update is called once per frame
    void Update()
    {
        Jump();

        // Find out what is beneath the player
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin.position, Vector2.down);

        // hit null check
        if(hit.collider != null)
        {
            // Send name of object to console
            Debug.Log(hit.transform.name);

            // Draw the ray under the player
            Debug.DrawRay(raycastOrigin.position, Vector2.down, Color.green);
        }
    }
    
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}
