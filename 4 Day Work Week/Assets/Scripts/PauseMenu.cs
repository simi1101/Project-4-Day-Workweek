using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public float pauseButton;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //pauseButton = Input.GetAxis("Cancel");



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        else
        {
            PlayGame();
        }
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
    
    public void PlayGame()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
