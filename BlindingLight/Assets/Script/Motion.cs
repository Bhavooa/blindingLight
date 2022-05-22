using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{

    public float velocity = 5f;
    public float sensitivity = 100f;
    public Transform player;
    Vector3 movement;
    Vector3 mousePosition;
    TeleportItem orbs;
    Timer time;
    Vector3 currentPos;
    bool canMove;
    bool isTeleporting;
    // Start is called before the first frame update    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        orbs = GameObject.FindObjectOfType(typeof(TeleportItem)) as TeleportItem;
        time = GameObject.FindObjectOfType(typeof(Timer)) as Timer;
        canMove = true;
        isTeleporting = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = player.position;
        if((orbs.getCount() > 0) && Input.GetKey("e")){
            isTeleporting = true;
            //remove one orb from count
            orbs.removeOrb();
        }
        if(isTeleporting){
            teleport();
        } else {
            movement.x = Input.GetAxis("Horizontal");
            movement.z = Input.GetAxis("Vertical");
            mousePosition = Input.mousePosition;
            movmentCalc();
            rotationCalc();
        }
    }
    //moves the character in acordance to the key inputs
    void movmentCalc(){
        transform.Translate(movement * velocity * Time.deltaTime);
    }

    void rotationCalc(){
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * -1;
        float mouseMotion = mouseX;
        player.Rotate(Vector3.up * mouseMotion);
    }

    void teleport(){
            //pause timer
            time.setTimerPause();
            //restrict ALL motion
            canMove = false;
            //show mouse
            Cursor.lockState = CursorLockMode.None;
            //change camera fov??
            //get mouse input location
            if(Input.GetMouseButton(0)){
                Debug.Log(Input.mousePosition);
                isTeleporting = false;

            }
            //teleport player to that position
            //player.position = mousePosition;
    }
}
