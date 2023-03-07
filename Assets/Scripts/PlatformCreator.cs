using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCreator : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab;
    [SerializeField] Transform referencePoint;
    [SerializeField] GameObject lastCreatedPlatform;

    // Start is called before the first frame update
    void Start()
    {
        lastCreatedPlatform = Instantiate(platformPrefab, referencePoint.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        // when platform reaches a certain point, spawn a new platform
        if(lastCreatedPlatform.transform.position.x < 0)
        {
            lastCreatedPlatform = Instantiate(platformPrefab, referencePoint.position, Quaternion.identity);
        }
    }
}
