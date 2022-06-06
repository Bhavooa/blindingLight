using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBestTime : MonoBehaviour
{
    Timer time;
    Text text;

    void Start()
    {
        time = GameObject.FindObjectOfType(typeof(Timer)) as Timer;
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = time.getBestTime() + "";
    }
}
