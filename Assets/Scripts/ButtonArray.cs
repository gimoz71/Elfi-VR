using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonArray : MonoBehaviour
{
    public GameObject canvasParent;
    public GameObject buttonPrefab;

    private void Start()
    {
        InstantiatePrefab();
    }
    void InstantiatePrefab()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject answer = Instantiate(buttonPrefab);

            answer.transform.SetParent(canvasParent.transform, false);

            Button tempButton = answer.GetComponent<Button>();

          

            answer.GetComponentInChildren<Text>().text = "Pulsante n°: " + i;


            int tempInt = i;


            tempButton.onClick.AddListener(() => ButtonClicked(tempInt));

           /*
            * Tentativo di far collimare il collider con la dimensione di un genitore
            * 
            var canvasHeight = canvasParent.GetComponent<RectTransform>().rect.height;
            var canvasWidth = canvasParent.GetComponent<RectTransform>().rect.width;
            Debug.Log("altezza " + i + ": " + canvasHeight);
            Debug.Log("larghezza " + i + ": " + canvasWidth);
            Debug.Log("-------------------------");


            var tempCollider = answer.GetComponent<BoxCollider>();

            tempCollider.size = new Vector3(canvasHeight, canvasWidth, 2);*/
        }
    }

    void ButtonClicked(int buttonNo)
    {
        Debug.Log("Button clicked = " + buttonNo);
    }
}
