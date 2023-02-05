using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject player;
    public GameObject lantern;
    public GameObject gauge;

    public Slider volumeSlider;
    public Slider sensitivitySlider;
    public static float volume;
    public static float cameraSensitivity;

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

        Cursor.lockState = CursorLockMode.None;

        // Set settings floats to equal slider values right away
        volume = volumeSlider.value;
        cameraSensitivity = sensitivitySlider.value;

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

        // Exiting the main menu
        inMenu = false;

        // Allow player to pause
        PauseMenu.isPaused = false;

        // Hide the cursor as player leaves the main menu
        Cursor.lockState = CursorLockMode.Locked;

        // Load the map scene
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetVolume()
    {
        volume = volumeSlider.value;
        //AkSoundEngine.SetRTPCValue("", volume);
    }

    public void SetCameraSensitivity()
    {
        cameraSensitivity = sensitivitySlider.value;
        PlayerLook.xSensitivity = cameraSensitivity;
        PlayerLook.ySensitivity = cameraSensitivity;
    }

    public void PlayCredits()
    {
        SceneManager.LoadScene(2);
        ExpEvent.Stop(gameObject);
    }
}