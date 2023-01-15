using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZoneTrigger : MonoBehaviour
{
    TemperatureMeter Meter;

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
        Meter.InSafeZone = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Meter.InSafeZone = false;
    }
}
