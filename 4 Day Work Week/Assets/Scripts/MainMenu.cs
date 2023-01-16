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
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<PlayerLook>().enabled = false;
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
        player.GetComponent<CharacterController>().enabled = true;
        player.GetComponent<PlayerLook>().enabled = true;
        mainMenuUI.SetActive(false);
        lantern.SetActive(true);
        dial.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
