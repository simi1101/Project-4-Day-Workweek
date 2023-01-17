using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{

    public AK.Wwise.Event creditMusic;
    // Start is called before the first frame update
    void Start()
    {
        creditMusic.Post(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
