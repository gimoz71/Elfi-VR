using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckCodiceLucchetto : MonoBehaviour
{

    public Text codice1;
    public Text codice2;
    public Text codice3;
    public Text codice4;
    public Text codice5;

    private string codice;

    public GameObject treasure;
    private Animation treasureAnimation;
    public Text risultato;

    // Start is called before the first frame update
    void Start()
    {
        var configManager = JSonConfigManager.Instance;
        configManager.OpenConfigFile(JSonConfigManager.ConfigFilePath);
        codice = configManager.getCombinazioneLucchetto();
        treasureAnimation = treasure.GetComponent<Animation>();
        //codice = "12345";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CodiceCheck()
    {
        risultato.text = string.Concat(codice1.text, codice2.text, codice3.text, codice4.text, codice5.text);

        if(risultato.text == codice)
        {
            Debug.Log("BRAVO!!!!!!!!");
            risultato.text = risultato.text + " OK!";
            treasureAnimation.Play();
        } else
        {
            Debug.Log("ERRORE!!");
            risultato.text = risultato.text + " NO!!!";
        }
    }
}
