using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{
    [SerializeField] AudioClip nightSound;
    [SerializeField] AudioClip daySound;
    [SerializeField] AudioSource audioSource;

    public void PlayNightSound()
    {
        audioSource.clip = nightSound;
        audioSource.Play();
    }

    public void PlayDaySound()
    {
        audioSource.clip = daySound;
        audioSource.Play();
    }
}
