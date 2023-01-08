using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    ResourceManager rm;
    public Collider collectionPoint;
    Vector3 cpPosition;
    public float pullForce;

    // Start is called before the first frame update
    void Start()
    {
        rm = gameObject.GetComponentInParent<ResourceManager>();
        cpPosition = collectionPoint.transform.position;
    }

    private void Update()
    {
        cpPosition = collectionPoint.transform.position;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.GetComponent<Coal>() != null)
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            //move rigidbody towards collection point
            Vector3 pullVector = cpPosition - rb.position;
            rb.AddForce((rb.mass * (pullVector) * pullForce));
            Debug.DrawLine(cpPosition, rb.position);
        }
     
    
    }
}
