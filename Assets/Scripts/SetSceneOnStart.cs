using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSceneOnStart : MonoBehaviour
{
    public Text sceneTitle;
    public GameObject scene1;
    public GameObject scene2;
    public GameObject scene3;
    public GameObject scene4;
    public GameObject scene5;
    public GameObject scene6;

    // Start is called before the first frame update
    void Awake()
    {
        scene1.SetActive(false);
        scene2.SetActive(false);
        scene3.SetActive(false);
        scene4.SetActive(false);
        scene5.SetActive(false);
        scene6.SetActive(false);
    }

    void Start()
    {

        Debug.Log("TEAM: " + SceneChanger.team + "SCENA: " + SceneChanger.scene);

        if (SceneChanger.team == 0)
        {
            SceneChanger.team = 1;
        }

        if (SceneChanger.scene == 0)
        {
            SceneChanger.scene = 1;
        }

        sceneTitle = GameObject.Find("Scene Title").GetComponent<Text>();

        // Scena 1 - Scavo
        if (SceneChanger.scene == 1)
        {
            scene1.SetActive(true);
            sceneTitle.text = "Scena 1";

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

        // Scena 2 - Tangram
        if (SceneChanger.scene == 2)
        {
            scene2.SetActive(true);
            sceneTitle.text = "Scena 2";


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

        // Scena 3 - Ghost lucchetto
        if (SceneChanger.scene == 3)
        {

            scene3.SetActive(true);
            sceneTitle.text = "Scena 3";

            GameObject ghostButton = GameObject.Find("Ghost");
            ghostButton.SetActive(true);


        } else {
            GameObject ghostButton = GameObject.Find("Ghost");
            ghostButton.SetActive(false);
        }

        // Scena 4 - Entità domande
        if (SceneChanger.scene == 4)
        {
            scene4.SetActive(true);
            sceneTitle.text = "Scena 4";

        }

        // Scena 5 - Descrizione oggetti
        if (SceneChanger.scene == 5)
        {
            scene5.SetActive(true);
            sceneTitle.text = "Scena 5";

        }

        // Scena 6 - Enigma finale
        if (SceneChanger.scene == 6)
        {
            scene6.SetActive(true);
            sceneTitle.text = "Scena 6";


            if (SceneChanger.team == 1)
            {
                GameObject lettereSimboli = GameObject.Find("BrickA");
                lettereSimboli.SetActive(false);
            }
            else
            {
                GameObject lettereSimboli = GameObject.Find("BrickB");
                lettereSimboli.SetActive(false);
            }
        } 
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
