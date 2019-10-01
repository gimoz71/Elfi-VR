using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swash : MonoBehaviour
{
    public AudioSource swoshAudio;
    public ParticleSystem splash;

    void Start()
    {
        splash.GetComponent<ParticleSystem>().Stop();
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "itemChild")
        {
            swoshAudio.Play();
            splash.GetComponent<ParticleSystem>().Play();
        }
    }
}
