using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnShape : MonoBehaviour //this is where beehive shape is returned
{
    //initializing needed values

    //public GameObject player;
    private CircleCollider2D originalShape;
    private CapsuleCollider2D bloatedShape;
    bool beehiveCollision;

    public void returnShape(bool beehiveCol)
    {
        beehiveCollision = beehiveCol;

        //getting both of the colliders on player/ball
        originalShape = gameObject.GetComponent<CircleCollider2D>();
        bloatedShape = gameObject.GetComponent<CapsuleCollider2D>();

        if (beehiveCollision == true)
        {
            beehiveCollision = false;
            transform.localScale += new Vector3(-0.5f, 0, -0.5f); //returning player shape to original
            originalShape.enabled = true;
            bloatedShape.enabled = false;
        }
    }
}
