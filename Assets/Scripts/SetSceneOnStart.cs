using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSceneOnStart : MonoBehaviour
{

    public GameObject scene1;
    public GameObject scene2;
    public GameObject scene3;
    public GameObject scene4;
    public GameObject scene5;
    public GameObject scene6;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("TEAM: " + SceneChanger.team + "SCENA: " + SceneChanger.scene);

        // SCENA

        if (SceneChanger.scene == 1) // DIG
        {
            scene1.SetActive(true);

            if (SceneChanger.team == 1)
            {
                GameObject lettereSimboli = GameObject.Find("LettereSimboliB");
                lettereSimboli.SetActive(false);
            } else
            {
                GameObject lettereSimboli = GameObject.Find("LettereSimboliA");
                lettereSimboli.SetActive(false);
            }

        }

        if (SceneChanger.scene == 2) // TANGRAM
        {
            scene2.SetActive(true);

            if (SceneChanger.team == 1)
            {
                GameObject lettereSimboli = GameObject.Find("TangramA");
                lettereSimboli.SetActive(false);
            }
            else
            {
                GameObject lettereSimboli = GameObject.Find("TangramB");
                lettereSimboli.SetActive(false);
            }

        }

        if (SceneChanger.scene == 3)
        {
            scene3.SetActive(true);
        }
        if (SceneChanger.scene == 4)
        {
            scene4.SetActive(true);
        }
        if (SceneChanger.scene == 5)
        {
            scene5.SetActive(true);
        }
        if (SceneChanger.scene == 6)
        {
            scene6.SetActive(true);
        }
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
