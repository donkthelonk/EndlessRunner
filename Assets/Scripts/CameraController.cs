using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 cameraVelocity;
    [SerializeField] float smoothTime = 1;
    [SerializeField] bool lookAtPlayer;
    [SerializeField] float lowerLimit = -18;

    // Update is called once per frame
    void Update()
    {
        if(player.position.y > lowerLimit)
        {
            //Not Smooth Movement
            //transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);

            //Smooth movement
            Vector3 targetPosition = new Vector3(transform.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref cameraVelocity, smoothTime);
            // Below causes an up/down perspective effect; only works in Projection mode Perspective; tbh kinda weird
            if (lookAtPlayer)
            {
                transform.LookAt(player);
            }
        }
    }
}
