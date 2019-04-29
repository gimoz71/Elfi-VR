using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using models;
using UnityEngine.SceneManagement;

public class ButtonArray : MonoBehaviour
{
    public GameObject AnswerParent;
    public GameObject buttonPrefab;
    public TextMeshProUGUI question;

    AudioSource answerConfirm;

    public AudioClip rightAnswerAudioClip;
    public AudioClip errorAnswerAudioClip;

    public Timer timer;

    public List<Domanda> domande = new List<Domanda>();
    public int indiceDomanda = 0;
    public int numeroRisposte = 0;

    private void Start()
    {
        var configManager = JSonConfigManager.Instance;
        if (SceneChanger.team == 1)
        {
            configManager.OpenConfigFile(JSonConfigManager.ConfigFilePathA);
        }
        if (SceneChanger.team == 2)
        {
            configManager.OpenConfigFile(JSonConfigManager.ConfigFilePathB);
        }
        domande = configManager.getDomandeSessione();


        answerConfirm = GetComponent<AudioSource>();
    }
    
    private void popolaDomanda(Domanda domanda) {
        resetAnswers();

        question.text = domanda.testo;
        var answerNumber = 1;
        foreach (var risposta in domanda.risposte) {
            GameObject answer = Instantiate(buttonPrefab);
            answer.name = "answer-" + answerNumber; 
            answer.transform.SetParent(AnswerParent.transform, false);
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
        timer.StopTimer();
        resetAnswers();
        question.text = "";
    }

    public void InitQuestion()
    {
        //timer.StartTimer();
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
            timer.ResetTimer();

            answerConfirm.PlayOneShot(rightAnswerAudioClip, 1f);
        }
        else {
            //gestione grafica errore risposta
            resetAnswers();
            timer.StopTimer();
            question.text = "";
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            answerConfirm.PlayOneShot(errorAnswerAudioClip, 1f);
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
