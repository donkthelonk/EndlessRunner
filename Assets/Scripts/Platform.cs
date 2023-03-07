using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] int speed = 2;

    // Update is called once per frame
    void Update()
    {
        //Move Platform
        //transform.Translate(-1, 0, 0);
        transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        if(transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }
}
