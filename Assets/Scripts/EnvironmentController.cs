using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    [SerializeField] GameObject environmentElement;
    [SerializeField] Transform referencePoint;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateEnvironmentElement());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CreateEnvironmentElement()
    {
        Instantiate(environmentElement, referencePoint.position, Quaternion.identity);
        yield return new WaitForSeconds(3);
        StartCoroutine(CreateEnvironmentElement());
    }
}
