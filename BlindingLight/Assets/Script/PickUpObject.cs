using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{

    public Collider orb;
    TeleportItem Orb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

   //checks to make sure that the orb touches the player
    void OnTriggerEnter(Collider other){
        if (other.transform.tag == "Player"){
            //moves orb out of view
            orb.transform.position = new Vector3(-20f, 0.5f, -20f);
            //adds count of teleport items to player
            Orb.addOrb();
        }
    }
}
