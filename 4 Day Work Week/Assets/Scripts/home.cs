using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class home : MonoBehaviour
{
    ObjectivesManager manager;
    bool inHome;

    public AK.Wwise.Event homeMusic;

    // Start is called before the first frame update
    void Start()
    {
        //homeMusic.Post(gameObject);
        inHome = false;
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (inHome != true)
        {
            homeMusic.Post(gameObject);
            inHome = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (inHome != false)
        {
            homeMusic.Stop(gameObject);
            inHome = false;
        }
    }

}
