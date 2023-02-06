using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectivesManager : MonoBehaviour
{
    Vector3 respawnPoint;
    int generatorCountOn;
    Collider winTrigger;

    // Start is called before the first frame update
    void Start()
    {
        winTrigger = GetComponent<Collider>();
        winTrigger.enabled= false;
        generatorCountOn = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if(generatorCountOn >= 4)
        {
            winTrigger.enabled = true;
        }
    }

    void Win()
    {
        //Load Win Screen
        AkSoundEngine.StopAll();
        SceneManager.LoadScene(2);
    }

    public void Lose()
    {
        //Go to lose screen
        AkSoundEngine.StopAll();
        SceneManager.LoadScene(0);
    }

   public void GeneratorActivated()
    {
        generatorCountOn += 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMotor>() != null)
        {
            Win();
        }
    }

    void PlayHome()
    {

    }
}
