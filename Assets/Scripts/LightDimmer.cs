using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDimmer : MonoBehaviour
{
    Light light;
    //public float dimmerValue;
    static public float value;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("ExecuteDimmer", 2);
        light = GetComponent<Light>();
        light.intensity = light.intensity - light.intensity / value;
        Debug.Log("Light intensity: " + light.intensity);
    }

    void ExecuteDimmer()
    {
        light = GetComponent<Light>();
        light.intensity = light.intensity - light.intensity / value;
        Debug.Log("Light intensity: " + light.intensity);
    }
}
