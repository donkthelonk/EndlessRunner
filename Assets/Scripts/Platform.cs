using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public int speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
