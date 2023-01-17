using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    float timer;

    public AK.Wwise.Event creditMusic;
    // Start is called before the first frame update
    void Start()
    {
        creditMusic.Post(gameObject);
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 65)
        {
            Application.Quit();
        }
    }
}
