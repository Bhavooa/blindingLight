using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text text;
    float timer;
    bool timerOn;
    // Start is called before the first frame update
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

    public void addExit(){
        text.text += "press enter to exit";
    }
}
