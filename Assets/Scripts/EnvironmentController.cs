using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    [SerializeField] GameObject[] environmentElement;
    [SerializeField] Transform referencePoint;
    [SerializeField] Vector3 offset;

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
        Instantiate(environmentElement[Random.Range(0, environmentElement.Length)], referencePoint.position + offset, Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(3, 6));
        StartCoroutine(CreateEnvironmentElement());
    }
}
