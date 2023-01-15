using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    int coalCount;
    public int maxCoalCount = 10;
    bool full;
    ObjectivesManager manager;

    // Start is called before the first frame update
    void Awake()
    {
        coalCount = 0;
        full = false;
        manager = GetComponentInParent<ObjectivesManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (full != true)
        {
            Coal coal = other.gameObject.GetComponent<Coal>();
            if (coal != null)
            {
                coalCount += coal.coalValue;
                Destroy(other.gameObject);
                //Audio for coal being deposited trigger here
                if(coalCount >= maxCoalCount)
                {
                    full = true;
                    ActivateGenerator();
                }
            }
        }

        void ActivateGenerator()
        {
            manager.GeneratorActivated();
            Debug.Log("Generator Activated");
            //FX and Audio for Activation trigger here
        }
    }
}
