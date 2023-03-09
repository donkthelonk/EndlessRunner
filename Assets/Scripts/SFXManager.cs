using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip coin;
    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip doubleJump;
    [SerializeField] AudioClip powerupDoubleJump;
    [SerializeField] AudioClip land;
    [SerializeField] AudioClip gameOverHit;
    [SerializeField] AudioClip powerupShield;
    [SerializeField] AudioClip shieldBreak;

    // Play SFX given the clipToPlay
    public void PlaySFX(string clipToPlay)
    {
        // assign approprite audio clip given clipToPlay
        switch (clipToPlay)
        {
            case "Coin":
                audioSource.clip = coin;
                break;
            case "Jump":
                audioSource.clip = jump;
                break;
            case "DoubleJump":
                audioSource.clip = doubleJump;
                break;
            case "PowerupDoubleJump":
                audioSource.clip = powerupDoubleJump;
                break;
            case "Land":
                audioSource.clip = land;
                break;
            case "GameOverHit":
                audioSource.clip = gameOverHit;
                break;
            case "PowerupShield":
                audioSource.clip = powerupShield;
                break;
            case "ShieldBreak":
                audioSource.clip = shieldBreak;
                break;
            default:
                break;
        }

        // play the audio clip assigned
        audioSource.Play();
    }
}
