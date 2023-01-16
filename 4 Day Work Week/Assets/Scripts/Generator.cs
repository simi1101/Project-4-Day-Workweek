using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    int coalCount;
    public int maxCoalCount = 10;
    bool full;
    ObjectivesManager manager;
    public SphereCollider safezone;
    public GameObject genFX;

    public AK.Wwise.Event coaldump;
    public AK.Wwise.Event generatorOn;
    public AK.Wwise.Event fireOn;

    // Start is called before the first frame update
    void Awake()
    {
        coalCount = 0;
        full = false;
        safezone.enabled = false;
        genFX.SetActive(false);
        
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
            safezone.enabled = true;
            genFX.SetActive(true);
            //FX and Audio for Activation trigger here
            fireOn.Post(gameObject);
            generatorOn.Post(gameObject);
        }
    }
}
