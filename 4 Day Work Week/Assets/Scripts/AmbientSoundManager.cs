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


    public bool footstepsPlaying;
    // Start is called before the first frame update
    void Start()
    {
        ambientSnow.Post(gameObject);
        ambientTrees.Post(gameObject);
        footstepsPlaying = false;
        
    }
    private void Awake()
    {
     

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FootstepsOn()
    {
        if (footstepsPlaying != true)
        {
            footstepsSnow.Post(gameObject);
            footstepsPlaying = true;
        }

    }

    public void FootStepsOff()
    {
        if (footstepsPlaying != false)
        {
            footstepsSnow.Stop(gameObject);
        }
    }
}
