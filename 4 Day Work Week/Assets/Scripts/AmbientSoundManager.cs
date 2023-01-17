using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSoundManager : MonoBehaviour
{

    public AK.Wwise.Event ambientSnow;
    public AK.Wwise.Event ambientTrees;
    public AK.Wwise.Event footstepsSnow;
    public AK.Wwise.Event enviroRandom;
    public AK.Wwise.Event homeMusic;


    bool footstepsPlaying;
    // Start is called before the first frame update
    void Start()
    {
        footstepsPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (footstepsPlaying != false)
        {

        }
    }

    void FootstepsOn()
    {
        footstepsSnow.Post(gameObject);

    }

    void FootStepsOff()
    {
        footstepsSnow.Stop(gameObject);
    }
}
