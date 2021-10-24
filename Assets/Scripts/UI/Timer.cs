using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public Text timeText;
    private RewardedAdsButton _adButtonStatus;

    private void Start()
    {
        _adButtonStatus = GameObject.FindGameObjectWithTag("AdButton").GetComponent<RewardedAdsButton>();
    }

    public float ChangeAdDisplay(float timer)
    {
        if (timer > 0)
        {
            timerIsRunning = true;
            _adButtonStatus.TimerRunning(true);
            return timeRemaining = timer;
        }
        else 
        {
            _adButtonStatus.TimerRunning(false);
            return timeRemaining = 0;
        }
        
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeText.text = "CLICK FOR 100G";
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = "Please Wait: "+string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}