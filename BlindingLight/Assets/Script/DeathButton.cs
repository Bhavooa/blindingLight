using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathButton : MonoBehaviour
{
    //sets at the first frame
    void Start(){
        //show mouse
        Cursor.lockState = CursorLockMode.None;
    }
    //called for onClick system, ment to load level one.
    public void ContinuePressed(){
        //loads level back to what it to try again.
        SceneManager.LoadScene("LevelOne");
    }
}
