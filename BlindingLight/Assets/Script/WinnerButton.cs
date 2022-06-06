using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerButton : MonoBehaviour
{
    void Start(){
        Cursor.visible = true;

    }
    public void ContinuePressed(){
        SceneManager.LoadScene("LevelTwo");
    }

    void Update(){
        if(Input.GetKey("return")){
            ContinuePressed();
        }
    }
}
