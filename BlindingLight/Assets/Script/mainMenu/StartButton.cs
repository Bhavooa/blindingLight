using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    //sets at the first frame
    void Start(){
        //sets resoloutiion
        Screen.SetResolution(2560,1600, true, 0);
        //show mouse
        Cursor.lockState = CursorLockMode.None;
    }

    //used for OnClick Method
    public void ContinuePressed(){
        //goes to first level
        SceneManager.LoadScene("LevelOne");
    }
}
