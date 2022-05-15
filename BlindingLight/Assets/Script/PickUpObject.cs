using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{

    public Collider orb;
    public float teleportCount;

   //checks to make sure that the orb touches the player
    void OnTriggerEnter(Collider other){
        if (other.transform.tag == "Player"){
            //moves orb out of view
            orb.transform.position = new Vector3(-20f, 0.5f, -20f);
            //adds count of teleport items to player
            addOrb();
        }
    }

    void addOrb(){
        teleportCount++;
    }

    public float getCount(){
        Debug.Log(teleportCount);
        return teleportCount;
    }
    void Update()
    {
       // Debug.Log(teleportCount);
    }
}
