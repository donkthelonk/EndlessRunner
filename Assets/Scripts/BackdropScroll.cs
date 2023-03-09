using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackdropScroll : MonoBehaviour
{
    SpriteRenderer renderer;
    [SerializeField] float speed = 1;
    float offset = 0;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        offset += Time.deltaTime * speed;
        renderer.material.mainTextureOffset = new Vector2(offset, 0);
    }
}
