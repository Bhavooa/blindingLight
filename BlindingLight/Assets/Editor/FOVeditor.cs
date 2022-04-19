using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FOV))]
public class FOVeditor : Editor
{
    private void onScreenGUI(){
        FOV fov = (FOV)target;
        Handles.color = color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.radius);

        Vector3 angleLeft = DirectionFromAngle(fov.transform.eulerAngles.y, -fov.angle/2);
        Vector3 angleRight = DirectionFromAngle(fov.transform.eulerAngles.y, fov.angle/2);

        Hangles.color = color.yellow;

        Hangles.DrawLine(fov.transform.position, fov.transform.position + angleLeft * fov.radius);
        Hangles.DrawLine(fov.transform.position, fov.transform.position + angleRight * fov.radius);

        if(fov.playerInView){
            Handles.color = color.green;
            Handles.DrawLine(fov.transform.position, fov.playerRef.transform.position);
        }
    }

    private Vector3 DirectionFromAngle(float eulerY, float angleInDeg){
        angleInDeg += eulerY;
        return new Vector3(Mathf.Sin(angleInDeg * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDeg * Mathf.Deg2Rad));
    }
}
