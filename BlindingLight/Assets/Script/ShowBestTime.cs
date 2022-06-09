using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBestTime : MonoBehaviour
{
    //gets the timer object, used to get best time
    Timer time;
    //gets text object to adjust display
    Text text;
    //saves the best time
    float bestTime;

    //sets at the first frame
    void Start()
    {
        //assings text componnent to text
        text = GetComponent<Text>();
        //assings timer class to time object
        time = GameObject.FindObjectOfType(typeof(Timer)) as Timer;
        //sets initial timer to zero
        bestTime = 0;
    }

    //called once per frame
    void Update()
    {
        //gets best time which has been saves to player reference with the name bestTime, will return 0 is no value was saved
        bestTime = PlayerPrefs.GetFloat("bestTime", 0);
        //sets text to display best time.
        text.text = bestTime + "";
    }
}
