using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinner : MonoBehaviour
{
    //gets the time class in order to set the best time
    Timer time;

    //sets at the first frame
    void Start()
    {
        //used to set best time
        time = GameObject.FindObjectOfType(typeof(Timer)) as Timer;
    }

    //used to check when object has touched another object
    void OnTriggerEnter(Collider other){
        //checks if object with tag of player has touched the orb
        if (other.transform.tag == "Player"){
            //sets the best time
            time.setBestTime();
            //loads gamewinner scenes
            SceneManager.LoadScene("GameWon");    
        }
    }
}
