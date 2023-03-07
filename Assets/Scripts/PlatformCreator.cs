using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCreator : MonoBehaviour
{
    [SerializeField] GameObject[] platformPrefab;
    [SerializeField] Transform referencePoint;
    [SerializeField] GameObject lastCreatedPlatform;
    [SerializeField] float spaceBetweenPlatforms = 2;
    private float lastPlatformWidth;

    // Start is called before the first frame update
    void Start()
    {
        //lastCreatedPlatform = Instantiate(platformPrefab, referencePoint.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        // when platform reaches a certain point, spawn a new platform
        if(lastCreatedPlatform.transform.position.x < referencePoint.position.x)
        {
            // New position to create platform
            Vector3 targetCreationPoint = new Vector3(referencePoint.position.x + lastPlatformWidth + spaceBetweenPlatforms, 0, 0);
            int randomPlatform = Random.Range(0, platformPrefab.Length);
            lastCreatedPlatform = Instantiate(platformPrefab[randomPlatform], targetCreationPoint, Quaternion.identity);

            // Get width of last platform
            BoxCollider2D collider = lastCreatedPlatform.GetComponent<BoxCollider2D>();
            lastPlatformWidth = collider.bounds.size.x;
        }
    }
}
