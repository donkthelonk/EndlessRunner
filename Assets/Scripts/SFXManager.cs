using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip coinSFX;
    [SerializeField] AudioClip jumpSFX;
    [SerializeField] AudioClip doubleJumpSFX;
    [SerializeField] AudioClip powerupDoubleJumpSFX;
    [SerializeField] AudioClip landSFX;
    [SerializeField] AudioClip gameOverHitSFX;
    [SerializeField] AudioClip powerupShieldSFX;
    [SerializeField] AudioClip shieldBreakSFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX(string clipToPlay)
    {
        if(clipToPlay == "Coin")
        {
            audioSource.clip = coinSFX;
        }

        if (clipToPlay == "Jump")
        {
            audioSource.clip = jumpSFX;
        }

        if(clipToPlay == "DoubleJump")
        {
            audioSource.clip = doubleJumpSFX;
        }

        if(clipToPlay == "PowerupDoubleJump")
        {
            audioSource.clip = powerupDoubleJumpSFX;
        }

        if (clipToPlay == "Land")
        {
            audioSource.clip = landSFX;
        }

        if (clipToPlay == "GameOverHit")
        {
            audioSource.clip = gameOverHitSFX;
        }

        if(clipToPlay == "PowerupShield")
        {
            audioSource.clip = powerupShieldSFX;
        }

        if (clipToPlay == "ShieldBreak")
        {
            audioSource.clip = shieldBreakSFX;
        }

        audioSource.Play();
    }
}
