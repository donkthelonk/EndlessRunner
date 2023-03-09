using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCreator : MonoBehaviour
{
    [SerializeField] GameObject[] platformPrefab;
    [SerializeField] Transform referencePoint;
    [SerializeField] GameObject lastCreatedPlatform;
    //[SerializeField] float spaceBetweenPlatforms = 2;
    [SerializeField] Player player;

    float lastPlatformWidth;


    // Start is called before the first frame update
    void Start()
    {
        //lastCreatedPlatform = Instantiate(platformPrefab, referencePoint.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        CreateNewPlatform();
    }

    private void CreateNewPlatform()
    {
        // when platform reaches a certain point, spawn a new platform
        if (lastCreatedPlatform.transform.position.x < referencePoint.position.x)
        {
            float randomSpaceInBetweenPlatforms = Random.Range(2, 5);

            // New position to create platform
            Vector3 targetCreationPoint = new Vector3(referencePoint.position.x + lastPlatformWidth + randomSpaceInBetweenPlatforms, referencePoint.position.y, 0);
            int randomPlatformIndex = Random.Range(0, platformPrefab.Length);
            lastCreatedPlatform = Instantiate(platformPrefab[randomPlatformIndex], targetCreationPoint, Quaternion.identity);

            // Get width of last platform
            BoxCollider2D collider = lastCreatedPlatform.GetComponent<BoxCollider2D>();
            lastPlatformWidth = collider.bounds.size.x;
        }

    }
}
