using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenu;
    public void Resume()
    {
        pauseMenu.SetActive(false);              //Pausemenu interface is disable
        Time.timeScale = 1f;                     //Time in the game is equal to 1 (Unstopped)
        gameIsPaused = false;
        Debug.Log("Game is resumed");
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);             //Pausemenu interface is enable
        Time.timeScale = 0f;                   //Time in the game is equal to 0 (Stopped)
        gameIsPaused = true;
        Debug.Log("Game is paused");
    }

    public void ChangePause()
    {
        if (gameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
    public void MainMenu()
    {
        Debug.Log("Going to the main menu!");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
