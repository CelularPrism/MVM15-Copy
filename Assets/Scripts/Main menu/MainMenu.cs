using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public static bool gameIsStarted = false;

    public static bool gameMenuIsOpen = false;

    public GameObject loadGameInterface;
    public GameObject startGameText;
    public GameObject inGameTimers;

    // Start is called before the first frame update
    void Start()
    {
        gameMenuIsOpen = true;

        gameIsStarted = PlayerPrefs.GetInt("GameIsStarted") == 1 ? true : false;  //Load game started bool

        //timer load
        inGameTimers.GetComponent<InGameTimer>().LoadTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            StartTheGame();
        }
    }

    private void StartTheGame()
    {
        if(gameIsStarted == false)
        {
            gameIsStarted = true;
            gameMenuIsOpen = false;
            PlayerPrefs.SetInt("GameIsStarted", gameIsStarted ? 1 : 0);      //Save game started bool
            SceneManager.LoadScene(1);
        }

        if (gameIsStarted)
        {
            startGameText.SetActive(false);
            loadGameInterface.SetActive(true);
        }
    }

    public void LoadGame()
    {
        gameMenuIsOpen = false;
        SceneManager.LoadScene(1);
    }

    public void NewGame()
    {
        gameMenuIsOpen = false;
        InGameTimer.hours = 0;
        InGameTimer.minutes = 0;
        InGameTimer.seconds = 0;
        SceneManager.LoadScene(1);
    }
}
