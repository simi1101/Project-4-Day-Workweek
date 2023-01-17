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

    public static bool inMenu;

    public AK.Wwise.Event ExpEvent;

    // Start is called before the first frame update
    void Start()
    {
        inMenu = true;
        player.GetComponent<InputManager>().enabled = false;
        mainMenuUI.SetActive(true);
        lantern.SetActive(false);
        gauge.SetActive(false);

        // Play title music
        ExpEvent.Post(gameObject);

        // Don't pause the game on the main menu
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

        // Exiting the main menu
        inMenu = false;

        // Allow player to pause
        PauseMenu.isPaused = false;

        Cursor.lockState = CursorLockMode.Locked;

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