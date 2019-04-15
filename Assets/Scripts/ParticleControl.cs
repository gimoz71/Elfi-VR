using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticleControl : MonoBehaviour
{




    public ParticleSystem pSystem;
    public Text controlParticle;

    public void Start()
    {
        pSystem.Stop();
        //pSystem.Stop();
    }

    public void ParticleToggle()
    {
        if(pSystem.isPaused == true || pSystem.isStopped == true)
        {
            pSystem.Play();
            controlParticle.text = "Pause";
        } else
        {
            //pSystem.Pause();
            pSystem.Stop();
            pSystem.Clear();
            controlParticle.text = "Play";
        }
    }
}