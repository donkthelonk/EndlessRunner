using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCreator : MonoBehaviour
{
    public GameObject platformPrefab;
    public Transform referencePoint;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(platformPrefab, referencePoint.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
