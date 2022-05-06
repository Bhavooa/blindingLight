using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{

    public float velocity = 5f;
    public float sensitivity = 100f;
    public Transform play;
    Vector3 movement;
    Vector3 mousePosition;
    // Start is called before the first frame update    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");
        mousePosition = Input.mousePosition;
        movmentCalc();
        rotationCalc();
        
    }
    //moves the character in acordance to the key inputs
    void movmentCalc(){
        transform.Translate(movement * velocity * Time.deltaTime);
    }

    void rotationCalc(){
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * -1;
        float mouseMotion = mouseX;
        play.Rotate(Vector3.up * mouseMotion);

    }

    // void OnTriggerEnter(Collider other){
    //     if (other.transform.tag == "Orb"){
    //         orbTouched = true;
    //     }
    // }

    // public bool hasTouchedOrb(){
    //     return orbTouched;
    // }
}
