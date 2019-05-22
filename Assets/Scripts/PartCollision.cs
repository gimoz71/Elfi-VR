using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


[ExecuteInEditMode]
public class PartCollision : MonoBehaviour
{
    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;

    public GameObject sword;
    public GameObject player;
    public AudioSource particleDeath;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
        particleDeath = GetComponent<AudioSource>();
        part.Stop();
    }

    void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

        //Rigidbody rb = other.GetComponent<Rigidbody>();
        int i = 0;

        while (i < numCollisionEvents)
        {
            //Debug.Log(i);
            if (other == player)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Debug.Log("COLLISION!!!");
            } else if (other == sword)
            {
                Debug.Log("KILL PARTICLE!!!!!");
                particleDeath.Play();
            }
            i++;
        }
    }
}