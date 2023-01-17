using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("Pausing");
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("Resuming");
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