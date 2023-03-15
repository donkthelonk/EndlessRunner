using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float distanceTraveled;

    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] Transform raycastOrigin;
    [SerializeField] Animator anim;
    [SerializeField] UIController uiController;
    [SerializeField] GameObject shieldBubblePrefab;
    [SerializeField] SFXManager sfxManager;
    [SerializeField] float jumpForce = 5;
    [SerializeField] float jumpCooldown = 0.5f;
    [SerializeField] int collectedCoins = 0;
    [SerializeField] bool jump;
    [SerializeField] bool isLanding;
    [SerializeField] bool airJump;
    [SerializeField] bool hasShield;
    [SerializeField] bool isGrounded;
    [SerializeField] bool isGameOver;
    [SerializeField] bool isJumpCooldown;

    private float lastYPos;

    private void Start()
    {
        // initialize player Y position
        lastYPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        IncreaseDistanceTraveled();
        CheckForInput();
        CheckForFalling();
    }

    void FixedUpdate()
    {
        CheckForGrounded();
        CheckForJump();
    }

    // Method to check for user input
    void CheckForInput()
    {
        // check if grounded or if air jump powerup active
        if(isGrounded || airJump)
        {
            // if so, check for user input for jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // only jump if not on cooldown
                if (!isJumpCooldown)
                {
                    // get rid of airjump if not grounded
                    if (airJump && !isGrounded)
                    {
                        airJump = false;
                    }

                    // enable jump
                    jump = true;

                    // Triggers the jump animation
                    anim.SetTrigger("Jump");

                    // Start cooldown Coroutine
                    StartCoroutine(JumpCooldown());
                }
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
                // play landing sound if initially landing
                if (!isGrounded)
                {
                    sfxManager.PlaySFX("Land");
                }

                isGrounded = true;

                anim.SetBool("isGrounded", true);
            }
            else
            {
                isGrounded = false;
                anim.SetBool("isGrounded", false);
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

    // Method for jumping logic
    void CheckForJump()
    {


        // check if user has pressed jump key; if so, reset jump bool and jump
        if (jump)
        {
            jump = false;

            // if grounded enabled, play normal jump sfx
            if (isGrounded)
            {
                sfxManager.PlaySFX("Jump");
                
            }
            // if not grounded enabled, play double jump sfx
            else
            {
                sfxManager.PlaySFX("DoubleJump");
            }

            playerRb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    // Method to check for falling state
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

    // Method to call from UIController to get collectedCoins from Player
    public int GetCollectedCoins()
    {
        return collectedCoins;
    }

    // Method to increase distanceTraveled based on Time.deltaTime
    private void IncreaseDistanceTraveled()
    {
        distanceTraveled += Time.deltaTime;
    }

    // Method to trigger the game over screen
    private void GameOver()
    {
        isGameOver = true;
        uiController.ShowGameOverScreen();

        // stop time
        Time.timeScale = 0;
    }

    // Method to check if game over is true
    public bool IsGameOver()
    {
        return isGameOver;
    }

    // Coroutine to wait between jump key presses
    IEnumerator JumpCooldown()
    {
        isJumpCooldown = true;
        yield return new WaitForSeconds(jumpCooldown);
        isJumpCooldown = false;
    }

    // Method for collision interactions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Obstacle collisions
        if(collision.transform.CompareTag("Obstacle"))
        {
            // if player has shield, deactivate shield and destroy obstacle
            if(hasShield)
            {
                // disable shield
                hasShield = false;

                // destroy the obstacle
                Destroy(collision.gameObject);

                // play shield break sfx
                sfxManager.PlaySFX("ShieldBreak");

                // hide shield sprite
                shieldBubblePrefab.SetActive(false);
            }
            // if not, game over
            else
            {
                sfxManager.PlaySFX("GameOverHit");
                GameOver();
            }
        }

        // Deathbox collisions
        if(collision.transform.CompareTag("Deathbox"))
        {
            GameOver();
        }
    }

    // Method for trigger interactions
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // destroy coin and increase collectedCoins 
        if (collision.CompareTag("Collectable"))
        {
            collectedCoins++;
            sfxManager.PlaySFX("Coin");
            Destroy(collision.gameObject);
        }

        // destroy air jump powerup object and enable airjump
        if(collision.CompareTag("AirJump") && !airJump)
        {
            airJump = true;

            // play double jump powerup sfx
            sfxManager.PlaySFX("PowerupDoubleJump");

            // destroy the airjump powerup object
            Destroy(collision.gameObject);
        }

        // destroy shield powerup object and enable shield
        if(collision.CompareTag("Shield") && !hasShield)
        {
            hasShield = true;

            // play powerup shield sfx
            sfxManager.PlaySFX("PowerupShield");

            // destroy the shield powerup object
            Destroy(collision.gameObject);

            // turn on shield
            shieldBubblePrefab.SetActive(true);
        }
    }
}
