using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackdropScroll : MonoBehaviour
{
    [SerializeField] float speed = 1;

    private SpriteRenderer renderer;
    private float offset = 0;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // update the offset based on speed * time
        offset += Time.deltaTime * speed;

        // move the sprite on the x axis by offset amount
        renderer.material.mainTextureOffset = new Vector2(offset, 0);
    }
}
