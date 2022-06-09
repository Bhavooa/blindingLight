using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrbCount : MonoBehaviour
{
    //keeps the count of orbs collected
    float orbCount;
    //get the text object adjust the object
    Text text;
    //gets the orb class in order to get the count of orbs
    TeleportItem orbs;

    //sets at the first frame
    void Start()
    {
        //gets the comonent text to adjust
        text = GetComponent<Text>();
        //calls the class object
        orbs = GameObject.FindObjectOfType(typeof(TeleportItem)) as TeleportItem;
    }

    // Update is called once per frame
    void Update()
    {
        //sets orb count to the value of given
        orbCount = orbs.getCount();
        //sets the text to the orb count
        text.text = orbCount + "";
    }
}
