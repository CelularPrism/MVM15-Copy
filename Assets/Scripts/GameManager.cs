using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private PauseMenu _pauseMenu;

    void Start()
    {
        _pauseMenu = GetComponent<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();                         //Restart the game
        }
        if (Input.GetKeyDown(KeyCode.Escape) && MainMenu.gameMenuIsOpen == false)
        {
            _pauseMenu.ChangePause();          // Pause or unpause
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
