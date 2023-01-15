using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectivesManager : MonoBehaviour
{
    Vector3 respawnPoint;
    int generatorCountOn;

    // Start is called before the first frame update
    void Start()
    {
        generatorCountOn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(generatorCountOn >= 4)
        {
            Win();
        }
    }

    void Win()
    {
        //Load Win Screen
        //SceneManager.LoadScene(0);
        Debug.Log("Win Screen Loaded!");
    }

    void Lose()
    {

    }

   public void GeneratorActivated()
    {
        generatorCountOn += 1;
    }
}
