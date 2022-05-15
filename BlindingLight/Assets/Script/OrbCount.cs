using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrbCount : MonoBehaviour
{

    float orbCount;
    Text text;
    PickUpObject orbs;

    void Start()
    {
        text = GetComponent<Text>();
        orbs = GameObject.Find("Orb").GetComponent<PickUpObject>();
    }

    // Update is called once per frame
    void Update()
    {
        orbCount = orbs.getCount();
        text.text = orbCount + "";
    }
}
