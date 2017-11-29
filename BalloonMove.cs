using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMove : MonoBehaviour {

    public BalloonPath PathToFollow; //getting the path for the balloon power up to move on

    //initializing needed values
    public int CurrentWaypointID = 0; 
    public float speed;
    private float reachDistance = 1.0f;
    public float rotationSpeed = 5.0f;

    private GameObject balloon;

    public AudioClip clip;

    bool headCollision;
    bool hasJoint;
    bool playAudio;

    Vector3 last_position;
    Vector3 current_position;

    FixedJoint jointToAdd;

    //getting the last position of player on start
    void Start() {
        last_position = transform.position;
        headCollision = false;
        playAudio = true;
    }

    void Update() {

        //returning rotation that rotates z aroung z, x around x and y around y axis to balloon
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);

        //if head collides with the balloon
        if (headCollision == true) {

            //distance between currentwaypoint (gizmo) and balloon
            float distance = Vector3.Distance(PathToFollow.path_objs[CurrentWaypointID].position, transform.position);

            //moving balloon position from one waypoint to the next waypoint with given speed
            transform.position = Vector3.MoveTowards(transform.position, PathToFollow.path_objs[CurrentWaypointID].position, Time.deltaTime * speed);

            //if distance is less than reachDistance move add one waypoint more
            if (distance <= reachDistance)
            {
                CurrentWaypointID++;

            }
            if (CurrentWaypointID >= PathToFollow.path_objs.Count) //if waypointID is bigger than the amount of gizmos on path --> destroy balloon
            {
                balloon = GameObject.Find("Balloon");
                Destroy(balloon.gameObject);
            }
        }
    }

    //detecting collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") //if colliding with player
        {
            headCollision = true;
            PlayAudio();

            //enabling fixedjoint between balloon and the player
            if (collision.gameObject.GetComponent<Rigidbody2D>() != null && !hasJoint)
            {
                gameObject.GetComponent<FixedJoint2D>().enabled = true;
                hasJoint = true;
            }
        }
    }
    //if audio clip = true --> play audio
    void PlayAudio() {
        if(playAudio == true) { 
            AudioSource.PlayClipAtPoint(clip, transform.position);
            playAudio = false;
        }
    }
   
}
