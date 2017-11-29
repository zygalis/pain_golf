using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this is the script where bouncing sound on trampoline is initialized
public class TrampolineSound : MonoBehaviour 
{
    //initializing needed values
    AudioSource Source;

    float SliderValue;

    void Start()
    {
        Source = GetComponent<AudioSource>(); //getting audiosource from trampoline
        Source.volume = 0.5f; //volume of the audio

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if collision with gameobject with tag Player
        if (collision.gameObject.tag == "Player") 
        {
            Source.Play();   //playing audio
        }
    }
}
