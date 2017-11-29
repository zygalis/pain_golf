using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOfNails : MonoBehaviour {

    //initializing needed values
    public float damage;
    private GameObject bat;

    private string newBatSprite;
    public Sprite[] sprites; //making a list for the sprites on sprite sheet


    void Awake()
    {
        bat = GameObject.Find("Bat"); //finging bat before it is disabled
    }
    void Start()
    {
        sprites = Resources.LoadAll<Sprite>("bats"); //adding sprites to the list from bats -sprite sheet 
    }
    //checking for collision
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Player") //if collision with object with tag Player
        {
            newBatSprite = bat.GetComponentInChildren<SpriteRenderer>().sprite.name + " Nails"; //assigning new bat sprite name

            foreach (Sprite sprite in sprites) //getting all the sprites in sprites list
            {
                if (sprite.name == newBatSprite) //if sprite name on list is the same as newBatSprite 
                {
                    for (int j = 0; j < sprites.Length; j++) //for loop to go through the list 
                    {
                        if (newBatSprite == sprites[j].name) // getting correct sprite with the same name as newBatSprite from sprites list
                        {
                            bat.GetComponentInChildren<SpriteRenderer>().sprite = sprites[j]; //updating bats sprite with sprite from the list
                        }
                    }
                }
            }
        }
        Destroy(gameObject); //destroying nails gameobject after collision
    }
}
