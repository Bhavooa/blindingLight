using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{

    //the speed at which the player moves
    float velocity = 5f;
    //the rate at which the playe rotates
    public float sensitivity;
    //the player reference, used for motion
    public Transform player;
    //placehoder for the rate of motion
    Vector3 movement;
    //the class orbs to get count and remove count
    TeleportItem orbs;
    //the timer class to pause and unpause timer
    Timer time;
    //determines is player is teleporting
    bool isTeleporting;
    //used to shoot raycast out of
    public Camera playerCam;
    //start position for reset reference
    Vector3 startPosition;

    //sets values for multiple varibles
    void Start()
    {
        //hides mouse from players view
        Cursor.lockState = CursorLockMode.Locked;
        //used later to keep count of teleport counts
        orbs = GameObject.FindObjectOfType(typeof(TeleportItem)) as TeleportItem;
        //used to pause timer later
        time = GameObject.FindObjectOfType(typeof(Timer)) as Timer;
        //is used to decide weather to run teleport method or normal motion method
        isTeleporting = false;
        //used as a reference
        startPosition = player.position;
    }

    // Update is called once per frame
    void Update()
    {
        //used to reset player back to where player started
        if(Input.GetKey("r")){
            player.position = startPosition;
            time.resetTimer();
            stopTeleport();
        }
        //checks if teleport is called and is possible due to orb count > 0
        if((orbs.getCount() > 0) && Input.GetKeyDown("e")){
            //sets the teleporting to true inorder to lock player movement
            isTeleporting = true;
        }
        //removes an orb from the count when e is realeased
        if(Input.GetKeyUp("e") && (orbs.getCount() > 0)){
            orbs.removeOrb();
        }
        //checks if the player is sappose to teleport rightnow
        if(isTeleporting){
            teleport();
        } else {
            //gets the horizontal movment on how 'a' or 'd'
            movement.x = Input.GetAxis("Horizontal");
            //gets the vertical movement on how 'w' or 's' was pressed
            movement.z = Input.GetAxis("Vertical");
            //goes to movment method to move
            movmentCalc();
            //goes to rotation method to rotate player
            rotationCalc();
        }
    }

    //moves the character in acordance to the key inputs
    void movmentCalc(){
        //transfrom the player to move acourding to movement Vector3
        //it changes acording to velocity and Time.deltaTime
        transform.Translate(movement * velocity * Time.deltaTime);
    }

    //rotates teh character
    void rotationCalc(){
        //get the rate of rotation based on mouse movement
        float mouseMotion = Input.GetAxis("Mouse X") * sensitivity;
        //make the player rotate
        player.Rotate(Vector3.up * mouseMotion);
    }


    //is the logic with which teleportation works with
    void teleport(){
        //pause timer
        time.setTimerPause();
        //show mouse
        Cursor.lockState = CursorLockMode.None;
        //get mouse input location
        if(Input.GetMouseButton(0)){
            //shoots a raycast to the mouse position
            Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
            //sees if the ray hits the targeted point
            if(Physics.Raycast(ray, out RaycastHit raycastHit)){
                //tranfrom player to the position of the mouse
                player.position = raycastHit.point;
            }
            //causes teleport to stop
            stopTeleport();
        }
    }

    //exits out of teleport phase
    void stopTeleport(){
        //casues the timer to resume
        time.setTimerPlay();
        //hides the mouse
        Cursor.lockState = CursorLockMode.Locked;
        //stops the teleporting to allow the motion
        isTeleporting = false;
    }
}
