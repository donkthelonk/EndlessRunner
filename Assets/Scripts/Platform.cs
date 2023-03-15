using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] int leftLimit = -50;

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
        DestroyPlatformOffScreen();
    }

    // Method for moving the platform
    void MovePlatform()
    {
        // Move Platform
        transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
    }

    // Method for destroying the platform once it reaches the leftLimit
    void DestroyPlatformOffScreen()
    {
        // destroy object once it reaches the left limit
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        }
    }
}
