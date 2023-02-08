using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject player;
    public GameObject lantern;
    public GameObject gauge;

    public Slider volumeSlider;
    public Slider sensitivitySlider;
    public static float volume;
    public static float cameraSensitivity;

    public static bool inMenu;
    public static bool gamePlayed;

    public AK.Wwise.Event titleMusic;

    private void Awake()
    {
        AkSoundEngine.StopAll();
        player.GetComponent<TemperatureMeter>().enabled = false;
        player.GetComponent<AmbientSoundManager>().enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        inMenu = true;
        player.GetComponent<InputManager>().enabled = false;
        lantern.SetActive(false);
        gauge.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        
       // Use settings from a previous playthrough
        if(gamePlayed)
        {
            volumeSlider.value = PauseMenu.volume;
            sensitivitySlider.value = PauseMenu.cameraSensitivity;
        }

        // Set settings floats equal to slider values right away
        volume = volumeSlider.value;
        cameraSensitivity = sensitivitySlider.value;

        AkSoundEngine.SetRTPCValue("Master_Volume", volume);

        // Play title music
        titleMusic.Post(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        player.GetComponent<InputManager>().enabled = true;
        player.GetComponent<TemperatureMeter>().enabled = true;
        player.GetComponent<AmbientSoundManager>().enabled = true;
        lantern.SetActive(true);
        gauge.SetActive(true);

        // Stop playing title music
        titleMusic.Stop(gameObject);

        // Exiting the main menu
        inMenu = false;

        // Allow player to pause
        PauseMenu.isPaused = false;

        // Track that game has been played at least once
        gamePlayed = true;

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
        AkSoundEngine.SetRTPCValue("Master_Volume", volume);
    }

    public void SetCameraSensitivity()
    {
        cameraSensitivity = sensitivitySlider.value;
    }

    public void PlayCredits()
    {
        SceneManager.LoadScene(2);
        titleMusic.Stop(gameObject);
    }
}