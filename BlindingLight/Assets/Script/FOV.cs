using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public float meshRes;
    public MeshFilter viewMeshFilter;
    Mesh viewMesh;
    public Transform badGuy;

    private void Start(){
        viewMesh = new Mesh();
        viewMesh.name = "View Mesh";
        viewMeshFilter.mesh = viewMesh;

        playerRef = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        FOVcheck();
        DrawFOV();
        //do quit condition here!!!!!!!!!!!!!!
        if(playerInView){
            SceneManager.LoadScene("DeathMenu");
        }
    }

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

    public void DrawFOV(){
        float stepCount = meshRes * angle;
        float stepAngleSize = angle / stepCount;
        List<Vector3> viewPoint = new List<Vector3>();
        for(int i = 0; i <= stepCount; i++){
            Vector3 hitPoint = getPoint(i);
            RaycastHit hit;
            if(Physics.Raycast(transform.position, hitPoint, out hit, radius, obstructionMask)){
                hitPoint = hit.point - transform.position;
            }
            //this adds the points that hit the edge of the beam
            viewPoint.Add(hitPoint);
        }
        int vertCount = viewPoint.Count + 1;
        Vector3[] vert = new Vector3[vertCount];
        int[] tri = new int[(vertCount - 2) * 3];
        Vector3 startPos = badGuy.position;
        startPos.y -= 0.5f;
        vert[0] = new Vector3(0f, 0f, 0f);
        for(int i = 0; i < vertCount - 1; i++){
            vert[i + 1] = (viewPoint[i]);
            if(i < vertCount - 2){
                tri[i * 3] = 0;
                tri[i * 3 + 1] = i + 1;
                tri[i * 3 + 2] = i + 2;
            }
        }

        viewMesh.Clear();
        viewMesh.vertices = vert;
        viewMesh.triangles = tri;
        viewMesh.RecalculateNormals();
    }


    public Vector3 getPoint(float tempAng){
        float angleOfBadGuy = transform.eulerAngles.y;
        float ang = (tempAng - 25) * Mathf.Deg2Rad;
        return new Vector3((radius * Mathf.Sin(ang)), -0.5f, (radius * Mathf.Cos(ang)));
    }

}
