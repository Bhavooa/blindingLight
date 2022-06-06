using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathButton : MonoBehaviour
{
    void Start(){
        Cursor.visible = true;

    }
    public void ContinuePressed(){
        SceneManager.LoadScene("LevelOne");
    }

    void Update(){
        if(Input.GetKey("return")){
            ContinuePressed();
        }
    }
}
