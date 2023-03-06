using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject controlsMenuUI;
    public GameObject optionsMenuUI;
    public GameObject player;
    public GameObject camera;
    public GameObject dialogue;
    public static bool isPaused = false;
    public static bool gamePlayed;

    public Slider volumeSlider;
    public Slider sensitivitySlider;
    public static float volume;
    public static float cameraSensitivity;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = MainMenu.volume;
        sensitivitySlider.value = MainMenu.cameraSensitivity;
        volume = volumeSlider.value;
        cameraSensitivity = sensitivitySlider.value;
        SetCameraSensitivity();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!MainMenu.inMenu)
            {
                if (isPaused)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
            else
            {
                return;
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        controlsMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        dialogue.SetActive(true);
        player.GetComponent<ResourceManager>().enabled = true;
        player.GetComponent<AmbientSoundManager>().enabled = true;
        Time.timeScale = 1f;
        isPaused = false;

        // Start all audio again as player leaves the pause menu
        camera.GetComponent<AkAudioListener>().enabled = true;

        // Hide the cursor as player leaves the pause menu
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        dialogue.SetActive(false);
        player.GetComponent<ResourceManager>().enabled = false;
        player.GetComponent<AmbientSoundManager>().enabled = false;
        Time.timeScale = 0f;
        isPaused = true;

        // Stop all audio while in pause menu
        camera.GetComponent<AkAudioListener>().enabled = false;

        // Show the cursor while in the pause menu
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void SetVolume()
    {
        volume = volumeSlider.value;
        AkSoundEngine.SetRTPCValue("Master_Volume", volume);
    }

    public void SetCameraSensitivity()
    {
        cameraSensitivity = sensitivitySlider.value;
        PlayerLook.xSensitivity = cameraSensitivity;
        PlayerLook.ySensitivity = cameraSensitivity;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayCredits()
    {
        AkSoundEngine.StopAll();
        SceneManager.LoadScene(2);
    }
}