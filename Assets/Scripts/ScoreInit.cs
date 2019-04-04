using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreInit : MonoBehaviour
{
    public static int scoreInc;
    // Start is called before the first frame update
    void Start()
    {
        //Give the PlayerPrefs some values to send over to the next Scene
        PlayerPrefs.SetInt("Score", 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
