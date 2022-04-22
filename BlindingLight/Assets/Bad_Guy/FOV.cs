using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angle;
    public GameObject playerRef;

//targetMask layer is the layer the player is on while obstructionMask is the layer everything else is on
    public LayerMask targetMask;
    public LayerMask obstructionMask;
    public bool playerInView;

    private float delay = 0.2f;

    private void start(){
        playerRef = GameObject.FindGameObjectWithTag("Player");
        //StartCoroutine(FOVroutine());
    }

    //waits to update/call FOVChecks 5 times every second instead of calling it every frame
    //optimization
    void Update()
    {
        FOVcheck();
    }

    // private IEnumerator FOVroutine(){
    //     WaitForSeconds wait = new WaitForSeconds(delay);
    //     while(true){
    //         yield return wait;
    //         FOVcheck();
    //     }
    // }

    private void FOVcheck(){
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);
        //this means that something has been found
        if(rangeChecks.Length != 0){
            //rangChecks at 0 would be the plaeyr as it is the first value the colider
            Transform target = rangeChecks[0].transform;
            //gets the change in the x, y, z values from the enimey location to the player location
            Vector3 dirToTarget = (target.position - transform.position);
        
            //this checks if the player that if found within a radius is also within the correct angle
            if(Vector3.Angle(transform.forward, dirToTarget) < angle/2){
                
                float disToTarget = Vector3.Distance(transform.position, target.position);
                //checks to make sure there isn't an object inbetween the player and the enimey.
                if(!Physics.Raycast(transform.position, dirToTarget, disToTarget, obstructionMask)){
                    playerInView = true;
                } else {
                    playerInView = false;
                }
            } else {
                playerInView = false;

            }
        } else if(playerInView){
            //resets the player view to false casue the player is not in view anymore.
            playerInView = false;
        }
    }
}
