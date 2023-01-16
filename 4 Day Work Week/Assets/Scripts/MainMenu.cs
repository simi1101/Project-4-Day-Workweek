using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject player;
    public GameObject lantern;
    public GameObject dial;
    
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<InputManager>().enabled = false;
        mainMenuUI.SetActive(true);
        lantern.SetActive(false);
        dial.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        player.GetComponent<InputManager>().enabled = true;
        mainMenuUI.SetActive(false);
        lantern.SetActive(true);
        dial.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
