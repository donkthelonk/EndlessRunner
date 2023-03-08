using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBubble : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Obstacle"))
        {
            Debug.Log("ShieldBubble hit Obstacle");

            // destroy the shield bubble
            Destroy(this.gameObject);
        }
    }
}
