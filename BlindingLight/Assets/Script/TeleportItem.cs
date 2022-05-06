using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportItem : MonoBehaviour
{

    public float teleportCount;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(teleportCount);
    }

    public void addOrb(){
        teleportCount = 2;
    }
}
