using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchDial : MonoBehaviour
{
    TemperatureMeter Meter;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Needle;
    public float RotateSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        Meter = GameObject.Find("Player").GetComponent<TemperatureMeter>();
    }

    // Update is called once per frame
    void Update()
    {
        Needle.transform.localEulerAngles = new Vector3(0, Meter.HealthBar, 0);
    }
}
