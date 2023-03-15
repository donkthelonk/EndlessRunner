using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{
    [SerializeField] AudioClip nightSound;
    [SerializeField] AudioClip daySound;
    [SerializeField] AudioSource audioSource;

    // Method for night time sound
    public void PlayNightSound()
    {
        audioSource.clip = nightSound;
        audioSource.Play();
    }

    // Method for day time sound
    public void PlayDaySound()
    {
        audioSource.clip = daySound;
        audioSource.Play();
    }
}
