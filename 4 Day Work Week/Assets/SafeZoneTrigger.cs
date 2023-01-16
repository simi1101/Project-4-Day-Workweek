using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZoneTrigger : MonoBehaviour
{
    TemperatureMeter Meter;
    Enemy enemy;
    public bool isGenerator;

    // Start is called before the first frame update
    void Start()
    {
        Meter = GameObject.Find("Player").GetComponent<TemperatureMeter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<TemperatureMeter>() != null)
        {
            TemperatureMeter meter = other.gameObject.GetComponent<TemperatureMeter>();
            Meter.InSafeZone = true;
            if(isGenerator != false)
            {
                meter.Healed = true;
            }
        }
        
        
            if(other.gameObject.GetComponent<Enemy>() != null)
        {
            enemy = other.gameObject.GetComponent<Enemy>();
                
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        Meter.InSafeZone = false;
        Meter.Healed = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>() != null)
        {
            enemy.Warded(transform.position);
        }
    }
}
