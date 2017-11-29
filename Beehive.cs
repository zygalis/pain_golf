using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beehive : MonoBehaviour
{
    //initializing needed values
    public float damage;
    public CircleCollider2D originalShape;
    public CapsuleCollider2D bloatedShape;
    public GameObject player;
    public Transform ball;
    bool beehiveCollision;
    bool hit;

    //getting Healthmanager script to use
    private HealthManager healthManager;

    //checking for collision with collider with isTrigger enabled
    void OnTriggerEnter2D(Collider2D collision)
    {
        //getting both of the colliders on player/ball
        originalShape = player.gameObject.GetComponent<CircleCollider2D>();
        bloatedShape = player.gameObject.GetComponent<CapsuleCollider2D>();

        hit = true;

        //if collision with gameobject with the tag Player
        if (collision.gameObject.tag == "Player")
        {
            if (hit == true)
            {
                hit = false;
                ball.localScale += new Vector3(0.5f, 0, 0.5f); //changing the shape of the player/ball

                originalShape.enabled = false;
                bloatedShape.enabled = true; 
                beehiveCollision = true; 

                GameManager.sharedGM.getShape(beehiveCollision); 
                healthManager = player.gameObject.GetComponent<HealthManager>(); //getting component Healthmanager from ball/player
                healthManager.reduceHealth(damage); //redusing health from player

            }
        }
        Destroy(gameObject); //destroying beehive after collision
    }
}





