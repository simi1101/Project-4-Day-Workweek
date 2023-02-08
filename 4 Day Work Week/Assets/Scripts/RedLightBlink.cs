using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLightBlink : MonoBehaviour
{
    public int blinkTime = 4;
    public int blinkLength = 1;
    Light myLight;
    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        myLight.intensity = Mathf.PingPong(Time.time/blinkTime, blinkLength);
    }
}
