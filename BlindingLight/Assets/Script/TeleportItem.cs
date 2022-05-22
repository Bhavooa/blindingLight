using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportItem : MonoBehaviour
{
    float teleportCount;
    Motion player;
    bool isTeleporting;


    void Start()
    {
        teleportCount = 0;
        player = GameObject.FindObjectOfType(typeof(Motion)) as Motion;

    }

    public float getCount(){
        return teleportCount;
    }

    public void addOrb(){
        teleportCount++;
    }

    public void removeOrb(){
        teleportCount--;
    }

    public void canTeleport(){
        isTeleporting = true;
    }
}
