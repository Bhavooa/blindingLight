using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrbCount : MonoBehaviour
{

    float orbCount;
    Text text;
    TeleportItem orbs;

    void Start()
    {
        text = GetComponent<Text>();
        orbs = GameObject.FindObjectOfType(typeof(TeleportItem)) as TeleportItem;
    }

    // Update is called once per frame
    void Update()
    {
        orbCount = orbs.getCount();
        text.text = orbCount + "";
    }
}
