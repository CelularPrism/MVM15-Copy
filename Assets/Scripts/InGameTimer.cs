using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InGameTimer : MonoBehaviour
{
    public static float seconds = 0,minutes = 0,hours = 0;

    public static int savedSeconds;

    public Text timeDisplay;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ConvertSecondsToMinutes();
        ConvertMinutesToHours();
        timeDisplay.text = (int)hours + ":" + (int)minutes + ":" + (int)seconds;

        Debug.Log("Seconds - " + seconds);

        if(MainMenu.gameMenuIsOpen == false && PauseMenu.gameIsPaused == false)
        {
            seconds += Time.deltaTime;
            SaveTimer();
        }
    }

    private void ConvertSecondsToMinutes()
    {
        if(seconds >= 60)
        {
            minutes += 1;
            seconds = 0;
        }
    }

    private void ConvertMinutesToHours()
    {
        if(minutes >= 60)
        {
            hours += 1;
            minutes = 0;
        }
    }

    //After we make a normal save, then this methods will be deleted.
    public void LoadTimer()
    {
        seconds = PlayerPrefs.GetInt("Seconds");
        minutes = PlayerPrefs.GetInt("Minutes");
        hours = PlayerPrefs.GetInt("Hours");
    }
    public void SaveTimer()
    {
        PlayerPrefs.SetInt("Seconds", (int)seconds);
        PlayerPrefs.SetInt("Minutes", (int)minutes);
        PlayerPrefs.SetInt("Hours", (int)hours);
    }
}
