using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportItem : MonoBehaviour
{
    //is the count of the teleport
    float teleportCount;
    //used to determine if teleportationis possible or not
    bool isTeleporting;

    //sets at the first frame
    void Start()
    {
        //sets the teleport count to 0 to start with
        teleportCount = 0;

    }

    //returns the count of how much teleportation is possible
    public float getCount(){
        return teleportCount;
    }

    //adds one to the count
    public void addOrb(){
        teleportCount++;
    }

    //removes one from count
    public void removeOrb(){
        teleportCount--;
    }
}
