using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject player;
    public GameObject lantern;
    public GameObject gauge;

    public AK.Wwise.Event ExpEvent;

    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<InputManager>().enabled = false;
        mainMenuUI.SetActive(true);
        lantern.SetActive(false);
        gauge.SetActive(false);

        // Play title music
        ExpEvent.Post(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        player.GetComponent<InputManager>().enabled = !false;
        mainMenuUI.SetActive(false);
        lantern.SetActive(true);
        gauge.SetActive(true);

        // Stop playing title music
        ExpEvent.Stop(gameObject);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayCredits()
    {
        //SceneManager.LoadScene(0);
    }
}