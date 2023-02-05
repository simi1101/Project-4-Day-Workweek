using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject dialogue;
    public static bool isPaused = false;

    public Slider volumeSlider;
    public Slider sensitivitySlider;
    public float volume;
    public float cameraSensitivity;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = MainMenu.volume;
        sensitivitySlider.value = MainMenu.cameraSensitivity;
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
                    return;
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
        Time.timeScale = 1f;
        isPaused = false;

        // Start all audio again as player leaves the pause menu
        // need to figure out what code goes here

        // Hide the cursor as player leaves the pause menu
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        // Stop all audio while in pause menu
        // need to figure out what code goes here

        // Show the cursor while in the pause menu
        Cursor.lockState = CursorLockMode.Confined;
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

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayCredits()
    {
        SceneManager.LoadScene(2);
    }
}