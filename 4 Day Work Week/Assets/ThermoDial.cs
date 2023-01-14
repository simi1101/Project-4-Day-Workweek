using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThermoDial : MonoBehaviour
{
 

    public GameObject Needle;
    // Start is called before the first frame update
    void Start()
    {
  
        Needle = GameObject.Find("Needle");

    }

    // Update is called once per frame
    void Update()
    {

    }
}
