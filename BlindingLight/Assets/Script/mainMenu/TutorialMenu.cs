using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialMenu : MonoBehaviour
{
    //sets at the first frame
    void Start(){
        //show mouse
        Cursor.lockState = CursorLockMode.None;
    }

    //used for OnClick Method
    public void ContinuePressed(){
        //goes to tutorial menu
        SceneManager.LoadScene("TutorialMenu");
    }
}
