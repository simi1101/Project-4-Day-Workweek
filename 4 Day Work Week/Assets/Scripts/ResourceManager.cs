using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResourceManager : MonoBehaviour
{
    int coalCount;
    int maxCoalCount;
    public Collider interactCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            Interact(true);
        }
        else
        {
            Interact(false);
        }
    }

    public void ModifyCoal(int amount)
    {
        coalCount += amount;
        Debug.Log(coalCount);
    }


    void Interact(bool state)
    {
        interactCollider.enabled = state;
    }

    
}
