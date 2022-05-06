using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text text;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timer = Mathf.Round(timer * 1000) / 1000;
        text.text = timer + "";
    }
}
