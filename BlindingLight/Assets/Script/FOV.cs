using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FOV : MonoBehaviour
{
    //the radius of the view of the bad guy, set to 5
    public float radius;

    //the angle of which the fov is, set to 50, can be a range from 0 to 360
    [Range(0, 360)]
    public float angle;

    //targetMask layer is the layer the player is on while obstructionMask is the layer everything else is on
    public LayerMask targetMask;

    //used for fov editor
    public GameObject playerRef;

    //obstructionMask is the layer used for objects that aren't the player, used to detect if player is hiding behind an object
    public LayerMask obstructionMask;

    //sets if the player is in view, adjusted when checking in FOVcheck(). Used to load death menu if needed.
    public bool playerInView;

    //used to make the mesh for the cone of the bad guys. So the player can see.
    public MeshFilter viewMeshFilter;

    //also used for the mesh
    Mesh viewMesh;


    public Transform badGuy;

    //sets at the first frame
    private void Start(){
        //makes new mesh
        viewMesh = new Mesh();
        //names mesh for reference
        viewMesh.name = "View Mesh";
        //used to create mesh
        viewMeshFilter.mesh = viewMesh;
    }

    //called every frame
    void Update()
    {
        //the logic of checking if player in view
        FOVcheck();
        //make the fov cone
        DrawFOV();
        //call death menu if player is in view
        if(playerInView){
            //load death menu
            SceneManager.LoadScene("DeathMenu");
        }
    }

    //logic of checking for player in view
    private void FOVcheck(){
        //loads all objects with targetMask(player) into a array when they are in range.
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);
        //this means that something has been found
        if(rangeChecks.Length != 0){
            //rangChecks at 0 would be the plaeyr as it is the first value the colider
            Transform target = rangeChecks[0].transform;
            //gets the change in the x, y, z values from the enimey location to the player location
            Vector3 dirToTarget = (target.position - transform.position);
        
            //this checks if the player that if found within a radius is also within the correct angle
            if(Vector3.Angle(transform.forward, dirToTarget) < angle/2){
                //the distance from the bad guy to the target
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

    //drawing the fov
    public void DrawFOV(){
        //used to store all the points where the edge of the fov should exist
        List<Vector3> viewPoint = new List<Vector3>();
        //goes though for every angle and finds the end point for each angle 
        for(int i = 0; i <= angle; i++){
            //used to find where the raycast has hit if it has hit an obstructionMask
            RaycastHit hit;
            //gets the max edge point of that angle of the cone, gets a Vector3, sends in the angle of rotation + 25 and the radius
            Vector3 hitPoint = getPoint(i, radius);
            //gets the real world position of the vector point
            Vector3 worldPos = transform.TransformPoint(hitPoint);
            //gets the distance in V3 from the end point to the original position
            Vector3 dirToTarget = (worldPos - transform.position);
            //checks if there is a obstruction layer between the max vertex and the start point
            if(Physics.Raycast(transform.position, dirToTarget, out hit, radius, obstructionMask)){    
                //send in the new distance posible for the new vertex, in reference to objects parent (bad guy)  
                hitPoint = getPoint(i, hit.distance);
            }
            //this adds the points that hit the edge of the beam
            viewPoint.Add(hitPoint);
        }
        //makes the value of which to interate through the cone (should be 51)
        int vertCount = viewPoint.Count + 1;
        //makes the array which is the length of the amoung of verticies needed
        Vector3[] vert = new Vector3[vertCount];
        //the size of the array which will hold the points of verticies
        int[] tri = new int[(vertCount - 2) * 3];
        //sets the start of each triangle to the initial position, its all 0 becasue the location is in reference to position to the bad guy
        vert[0] = new Vector3(0f, -0.5f, 0f);
        //interates for each point where there should be a verticies
        for(int i = 0; i < vertCount - 1; i++){
            //starts from the second verticie and takes the first verticy
            vert[i + 1] = viewPoint[i];
            //this assaigns the point of triangles
            if(i < vertCount - 2){
                //every three points in this array will be the initial point
                tri[i * 3] = 0;
                //sets the second and thrid point in each triplet of array sets
                tri[i * 3 + 1] = i + 1;
                tri[i * 3 + 2] = i + 2;
            }
        }

        //resets the mesh every frame
        viewMesh.Clear();
        //sets the verticies of the mesh to the vert array
        viewMesh.vertices = vert;
        //sets the meshes triangles to the triangle array
        viewMesh.triangles = tri;
        //calculates the triangles to verticies alignment, also sets the UV
        viewMesh.RecalculateNormals();
    }

    //gets the furthest point
    public Vector3 getPoint(float tempAng, float dis){
        //sets the angle to the appropriacte value and changes the degres to radians
        float ang = (tempAng - 25) * Mathf.Deg2Rad;
        //returns the change the furthest point 
        return new Vector3((dis * Mathf.Sin(ang)), -0.5f, (dis * Mathf.Cos(ang)));
    }

}
