using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    //initializing needed values
    public float speed = 225;
    public float damage = 15;
    public AudioClip clip;
    private Rigidbody2D player;
    HealthManager hm;
    Transform explosion;
    ParticleSystem[] childParticleSystems; //list for particle systems on bomb
    ParticleSystem.EmissionModule childPSEmissionModule;
    bool disabledRelevantPSEmissions = false;

    void Start()
    {
        explosion = transform.Find("PS_Explosion").GetComponent<Transform>(); //getting the particle system of the bomb
        childParticleSystems = explosion.GetComponentsInChildren<ParticleSystem>(); //getting all child particle sysctems of the particle system
        if (!disabledRelevantPSEmissions) //if relevant particle system emmission is if enabled
        {
            //getting all items on childParticleSystems list
            foreach (ParticleSystem childPS in childParticleSystems)
            {
                childPSEmissionModule = childPS.emission;
                childPSEmissionModule.enabled = false; //disabling emmision on items from the list
            }
            disabledRelevantPSEmissions = true;
        }
    }

    //checking collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if collision with object with tag Player
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = Resources.Load<Sprite>("");
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;

            //playing all particle systems from bomb
            foreach (ParticleSystem childPS in childParticleSystems)
            {
                childPSEmissionModule = childPS.emission;
                childPSEmissionModule.enabled = true;
            }
            PlayAudio(); //play soundeffect

            hm = collision.gameObject.GetComponent<HealthManager>(); //get Healthmanager script from player
            player = collision.gameObject.GetComponent<Rigidbody2D>(); //get player

            if (player != null)
            {
                Vector2 velocity = player.velocity;
                player.AddForce(-velocity * speed); //adding force to player
                hm.reduceHealth(damage); //reducing health
            }
    }
        StartCoroutine(stopExplosion()); //start coroutine
    }
    IEnumerator stopExplosion()
    {
        yield return new WaitForSeconds(2.1f); //wait before destroying bomb gameobject
        Destroy(gameObject);
    }
    void PlayAudio()
    {
        AudioSource.PlayClipAtPoint(clip, transform.position); //play bomb soundeffect
    }
}
