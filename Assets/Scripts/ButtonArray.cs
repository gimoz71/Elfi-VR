using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using models;

public class ButtonArray : MonoBehaviour
{
    public GameObject canvasParent;
    public GameObject buttonPrefab;
    public TextMeshProUGUI question;

    public List<Domanda> domande = new List<Domanda>();
    public int indiceDomanda = 0;
    public int numeroRisposte = 0;

    private void Start()
    {
        var configManager = JSonConfigManager.Instance;
        configManager.OpenConfigFile(JSonConfigManager.ConfigFilePath);
        domande = configManager.getDomandeSessione();

        //var combinazioneLucchetto = configManager.getCombinazioneLucchetto();

        InitQuestion();
    }

    private void popolaDomanda(Domanda domanda) {
        resetAnswers();

        question.text = domanda.testo;
        var answerNumber = 1;
        foreach (var risposta in domanda.risposte) {
            GameObject answer = Instantiate(buttonPrefab);
            answer.name = "answer-" + answerNumber; 
            answer.transform.SetParent(canvasParent.transform, false);
            Button tempButton = answer.GetComponent<Button>();
            answer.GetComponentInChildren<Text>().text = risposta.testo;
            tempButton.onClick.AddListener(() => ButtonClicked(risposta.id, domanda.idDomanda));
            answerNumber++;
        }

        numeroRisposte = answerNumber;
        indiceDomanda++;
    }

    private void resetAnswers() {
        for (var i = 1; i <= numeroRisposte; i++) {
            var obj = GameObject.Find("answer-" + i);
            Destroy(obj);
        }
        numeroRisposte = 0;
    }

    private void popolaFineOK() {
        resetAnswers();
        question.text = "BRAVO";
    }

    void InitQuestion()
    {
        if (domande.Count > 0) {
            popolaDomanda(domande[indiceDomanda]);
        }

    }

    void ButtonClicked(string idRisposta, string idDomanda )
    {
        //verifica risposta
        if (idRisposta.Equals(getRispostaValidaId(idDomanda)))
        {
            //gestione grafica risposta corretta
            if (indiceDomanda == domande.Count)
            {
                //sono arrivato alla fine delle domande
                popolaFineOK();
            }
            else {
                popolaDomanda(domande[indiceDomanda]);
            }
            
        }
        else {
            //gestione grafica errore risposta
            resetAnswers();
            question.text = "SCEMO";
        }
    }

    private string getRispostaValidaId(string idDomanda) {
        var rispostaId = "0";

        foreach (var domanda in domande) {
            if (domanda.idDomanda.Equals(idDomanda)) {
                return domanda.rispostaValida;
            }
        }

        return rispostaId;
    }
}
