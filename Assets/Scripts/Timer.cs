﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text startStopText;
    public TextMeshProUGUI countDown;
    public Text countDownUI;
    public TextMeshProUGUI message;
    Coroutine startRitardoLancio;
    public Text tempoInput;
    public int tempo = 180;


    private float duration;
    private bool isPaused;

    private int min;
    private int sec;

    public ButtonArray buttonArrayCredit;

    public FinalFade fade;

    void Awake()
    {
        if (SceneChanger.scene == 4)
        {
            countDown = GameObject.Find("QuestionCountdownText").GetComponent<TextMeshProUGUI>();
            message = GameObject.Find("QuestionText").GetComponent<TextMeshProUGUI>();
        }
        else
        {
            countDown = GameObject.Find("Countdown_text").GetComponent<TextMeshProUGUI>();
            message = GameObject.Find("Messaggio").GetComponent<TextMeshProUGUI>();
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {

        //tempo = int.Parse((tempoInput.text == "" ? "10" : tempoInput.text));
        //tempo = 180;

        isPaused = true;
        if (startStopText)
        {
            startStopText.text = "Timer start";
        }
        StartTimer();

        fade = GameObject.Find("Finale").GetComponent<FinalFade>();

    }
    
    // Avvio il Timer

    public void StartTimer()
    {
        startRitardoLancio = StartCoroutine(ritardoTempo(tempo));
    }

    

    // Resetto il Timer


    public void ResetTimer()
    {
        tempo = int.Parse((tempoInput.text == "" ? tempo+"" : tempoInput.text));
        duration = tempo;
        min = Mathf.FloorToInt(duration / 60);
        sec = Mathf.FloorToInt(duration % 60);
        countDown.text = min.ToString("00") + ":" + sec.ToString("00");
        countDownUI.text = countDown.text;
    }



    // Avvio e metto in pausa il Timer

    public void StartPauseTimer()
    {
       
        if (isPaused == true)
        {
            
            if (startStopText)
            {
                startStopText.text = "Timer pause";
            }
            isPaused = false;
        } else
        {
            if (startStopText)
            {
                startStopText.text = "Timer start";
            }
            isPaused = true;
        }
            
    }


    // Stoppo il Timer

    public void StopTimer()
    {
        StopCoroutine(startRitardoLancio);
    }



    // routine per il calcolo del tempo

    public IEnumerator ritardoTempo(float myDelay)
    {

        duration = myDelay;

        min = Mathf.FloorToInt(duration / 60);
        sec = Mathf.FloorToInt(duration % 60);
        countDown.text = min.ToString("00") + ":" + sec.ToString("00");
        countDownUI.text = countDown.text;

        while (duration > 0)
        {
            while (isPaused)
            {
                yield return null;
            }

            yield return new WaitForSeconds(1);
            duration--;

            min = Mathf.FloorToInt(duration / 60);
            sec = Mathf.FloorToInt(duration % 60);
            countDown.text = min.ToString("00") + ":" + sec.ToString("00");
            countDownUI.text = countDown.text;

            while (isPaused)
            {
                yield return null;
            }
        }
        //
        if (SceneChanger.scene == 4)
        {
            message.text = " Tempo Scaduto." + "<br><br>Hai guadagnato " + buttonArrayCredit.credit + " punti";
        }
        else
        {
            message.text = "Tempo Scaduto";
        }

        fade.enable();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
