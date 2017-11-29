using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonPath : MonoBehaviour {

    //Assingning the color of the ray and creating an array for the gizmos of the balloon path
    public Color rayColor = Color.white;
    public List<Transform> path_objs = new List<Transform>();
    Transform[] theArray;


    //function to draw the gizmos and the path to scene view; doesn't show on game view
    void OnDrawGizmos(){
        Gizmos.color = rayColor;
        theArray = GetComponentsInChildren<Transform>();
        path_objs.Clear();

        //getting all of the gizmos from game to the array
        foreach (Transform path_obj in theArray) {
            if (path_obj != this.transform) {
                path_objs.Add(path_obj);
            }
        }

        //a for loop to print ray between the gizmos
        for (int i = 0; i < path_objs.Count; i++) {
            Vector3 position = path_objs[i].position;
            if (i > 0) {
                Vector3 previous = path_objs[i-1].position;
                Gizmos.DrawLine(previous, position);
                Gizmos.DrawWireSphere(position, 0.3f);
            }
        }
    }
}
