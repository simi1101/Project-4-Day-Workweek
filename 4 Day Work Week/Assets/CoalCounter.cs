using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoalCounter : MonoBehaviour
{
    ResourceManager Torch;
    public TMP_Text Counter;
    string CoalNumber;

    // Start is called before the first frame update
    void Awake()
    {
        Torch = GameObject.Find("Player").GetComponent<ResourceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CoalNumber = Torch.coalCount.ToString("D2");

        Counter.text = CoalNumber;
        //string textVariable = Meter.HealthBar;
    }
}
