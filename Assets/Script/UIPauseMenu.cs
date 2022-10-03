using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false ;

    public GameObject player;

    public GameObject uiPauseMenu;
    private GameObject mainMenu;
    private GameObject optionsMenu;

    private void Start()
    {
        mainMenu = uiPauseMenu.transform.Find("PauseMenu").gameObject;
        optionsMenu = uiPauseMenu.transform.Find("OptionsMenu").gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
                return;
            }
            Pause();
        }
    }

    public void Resume()
    {
        uiPauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        
        // Remove all Physical Restrictions
        player.GetComponent<Player>().canWalk = true;
    }

    public void Pause()
    {
        uiPauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;

        // Impose Physical Restrictions
        player.GetComponent<Player>().canWalk = false;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ReturnToMainPauseMenu()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void GoToOptionsPauseMenu()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
}
