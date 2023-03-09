using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip coinSFX;
    [SerializeField] AudioClip jumpSFX;

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

        if(clipToPlay == "Jump")
        {
            audioSource.clip = jumpSFX;
        }

        audioSource.Play();
    }
}
