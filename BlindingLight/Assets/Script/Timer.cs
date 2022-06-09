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

    //sets at the first frame
    void Start()
    {
        //gets text component to change later
        text = GetComponent<Text>();
        //has timer start at zero
        timer = 0;
        //initialy has timer on
        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        //checks to make sure game has not been paused
        if(timerOn){
            //adds time elapsed to timer
            timer += Time.deltaTime;
        }
        //shrinks timer down to a 3 places after the decimal.
        timer = Mathf.Round(timer * 1000) / 1000;
        //sets text to the value of timer in order to display
        text.text = timer + "";
    }

    //paused timer by setting it to false
    public void setTimerPause(){
        timerOn = false;
    }

    //restarts timer
    public void setTimerPlay(){
        timerOn = true;
    }

    //sets best time
    public void setBestTime(){
        //the best time is the last recorded time
        bestTime = timer;
        //adds best time into player reference, under the name best time
        PlayerPrefs.SetFloat("bestTime", bestTime);
        //saves given values
        PlayerPrefs.Save();
    }
    
    //resets timer count to 0
    public void resetTimer(){
        timer = 0;
    }
}
