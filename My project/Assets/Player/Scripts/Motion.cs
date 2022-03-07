using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{

    public float velocity = 5f;
    public Rigidbody player;
    public Camera cam;
    Vector3 movement;
    Vector3 mousePosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mousePosition);
        movmentCalc();
        rotationCalc();
        
    }
    //moves the character in acordance to the key inputs
    void movmentCalc(){

        //gets key inputs via predefined function
        

        player.MovePosition(player.position + movement * velocity * Time.deltaTime);
    }

    void rotationCalc(){
        Vector3 targetDir = mousePosition - player.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        player.rotation = rotation;
    }
}
