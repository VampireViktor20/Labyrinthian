using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Maze maze;
    public float timeValue = 5f;
    public Text timer;

    void Start()
    {
        
    }

    void Update()
    {
        if (timeValue > 0f)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue += 6f;
            maze.Regenerate();
        }
        DisplayTimer(timeValue);

        
        void DisplayTimer(float timerToDisplay)
        {
            if(timerToDisplay < 0f)
            {
                timerToDisplay = 0f;
            }

            float minutes = Mathf.FloorToInt(timerToDisplay / 60);
            float seconds = Mathf.FloorToInt(timerToDisplay % 60);
            timer.text = string.Format("{00}:{1:00}", minutes, seconds);
        }
    }







}
