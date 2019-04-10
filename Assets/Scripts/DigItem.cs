using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigItem : MonoBehaviour
{

    //public GameObject item;
    private GameObject itemChild;
    private GameObject markerChild;
    private MeshRenderer itemChildRenderer;
    public ParticleSystem picconata;
    private int picconataCounter;

    // Start is called before the first frame update
    void Start()
    {
        itemChild = transform.Find("item").gameObject;
        markerChild = transform.Find("marker").gameObject;

        picconata.GetComponent<ParticleSystem>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "Piccone")
        {
            picconataCounter++;

            Debug.Log(picconataCounter);

            if (picconataCounter == 8) {
                itemChild.SetActive(true);
                markerChild.SetActive(false);
            }
            Explode();
        }
    }

    void Explode()
    {
        
        picconata.GetComponent<ParticleSystem>().Play();
    }
}
