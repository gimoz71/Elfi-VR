using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class PartCollision : MonoBehaviour
{
    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;

    public GameObject sword;
    public GameObject player;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

        //Rigidbody rb = other.GetComponent<Rigidbody>();
        int i = 0;

        while (i < numCollisionEvents)
        {
            Debug.Log(i);
            if (other.name == "HeadCollider")
            {
                
                Debug.Log("COLLISION!!!");
            } else if (other.name == "sword")
            {
                Debug.Log("KILL PARTICLE!!!!!");
            }
            i++;
        }
    }
}