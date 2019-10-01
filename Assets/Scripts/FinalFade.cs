using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aura2API;

public class FinalFade : MonoBehaviour
{
    //public AuraBaseSettings setFade;
    public AuraVolume globalVolume;

    public float min = 0.025f;
    public float max = 2;
    public float startValue = 0.025f;
    public float changePerSecond = 0.1f;
    public bool triggerEnd = false;
    


    // Update is called once per frame
    void Update()
    {
        //Debug.Log("VALUE :" + startValue);
        if (triggerEnd)
        {
            globalVolume.densityInjection.strength = startValue;
            globalVolume.lightInjection.injectionParameters.strength = startValue;
            startValue += changePerSecond;
        }
    }

    public void enable()
    {
        triggerEnd = true;
    }

 
}
