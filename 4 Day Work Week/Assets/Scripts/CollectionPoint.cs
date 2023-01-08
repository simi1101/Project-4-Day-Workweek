using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionPoint : MonoBehaviour
{
    ResourceManager rm;

    private void Start()
    {
        rm = GetComponentInParent<ResourceManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Coal>() != null)
        {
            Coal coal = other.gameObject.GetComponent<Coal>();
            rm.ModifyCoal(coal.coalValue);
            Destroy(other.gameObject);
        }
    }
}
