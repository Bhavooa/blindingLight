using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //calls text in order to change it
    Text text;
    //saves the time
    float timer;
    //determins if timer is paused or not
    bool timerOn;
    //saves best time to show to player at the end
    float bestTime;

    void Start()
    {
        
        text = GetComponent<Text>();
        timer = 0;
        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerOn){
            timer += Time.deltaTime;
        }
        timer = Mathf.Round(timer * 1000) / 1000;
        text.text = timer + "";
    }

    public void setTimerPause(){
        timerOn = false;
    }

    public void setTimerPlay(){
        timerOn = true;
    }

    public void addExit(){
        text.text += "press enter to exit";
    }

    public void setBestTime(){
        bestTime = timer;
    }

    public float getBestTime(){
        return timer;
    }

}
