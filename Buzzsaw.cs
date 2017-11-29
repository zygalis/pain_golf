using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buzzsaw : MonoBehaviour {

    //rotation speed of the buzzsaw
    public float rotateSpeed;

    void Update()
    {
        //rotating buzzsaw on z axis
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
}
