using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    //initializing needed values
    private GameObject redPortal; 
    private GameObject player;

    void Start() {
       redPortal = GameObject.Find("PS_RedPortal");  //finding destination portal
       player = GameObject.Find("Ball");
    }

    //checking collision
    void OnTriggerEnter2D(Collider2D portal)
    {
            //player moved to destination portal
            player.transform.position = redPortal.transform.position;
    }
}
