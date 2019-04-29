using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swash : MonoBehaviour
{
    public AudioSource swoshAudio;

    

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "itemChild")
        {
            swoshAudio.Play();
        }
    }
}
