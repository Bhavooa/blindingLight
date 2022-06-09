using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    //gets the collider of the orb to check the touch of the player
    public Collider orb;
    //used to count the amount of orbs
    TeleportItem counter;
    //gets the start location of the orb, used to reset
    Vector3 startLocation;

    //sets at the first frame
    void Start()
    {
        //gets the class of the object
        counter = GameObject.FindObjectOfType(typeof(TeleportItem)) as TeleportItem;
        //saves the start location of the orb
        startLocation = orb.transform.position;
    }

   //checks to make sure that the orb touches the player
    void OnTriggerEnter(Collider other){
        //checks if player has touched the orb
        if (other.transform.tag == "Player"){
            //moves orb out of view
            orb.transform.position = new Vector3(-15f, 0.5f, -20f);
            //adds count of teleport items to player
            counter.addOrb();
        }
    }

    //called once per frame
    void Update()
    {
        //used to reset player back to where player started
        if(Input.GetKey("r")){
            //sets the position of the orb to where it started from
            orb.transform.position = startLocation;
            //loops for the amount of orbs in a object
            for(int i = 0; i < counter.getCount(); i++){
                //removes each orb from count display
                counter.removeOrb();
            }
        }
    }
}
