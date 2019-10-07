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
    public TextMeshProUGUI message;
    Coroutine startRitardoLancio;
    public Text tempoInput;
    public int tempo = 180;


    private float duration;
    private bool isPaused;

    private int min;
    private int sec;

    public ButtonArray buttonArrayCredit;


    

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTimer()
    {
        startRitardoLancio = StartCoroutine(ritardoTempo(tempo));
    }

    public IEnumerator ritardoTempo(float myDelay)
    {
        

        duration = myDelay;

        min = Mathf.FloorToInt(duration / 60);
        sec = Mathf.FloorToInt(duration % 60);
        countDown.text = min.ToString("00") + ":" + sec.ToString("00");

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

            while (isPaused)
            {
                yield return null;
            }
        }
        //
        message.text = " Tempo Scaduto." + "<br><br>Hai guadagnato " + buttonArrayCredit.credit + " punti";
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

 

    public void ResetTimer()
    {
        tempo = int.Parse((tempoInput.text == "" ? tempo+"" : tempoInput.text));
        duration = tempo;
        min = Mathf.FloorToInt(duration / 60);
        sec = Mathf.FloorToInt(duration % 60);
        countDown.text = min.ToString("00") + ":" + sec.ToString("00");
    }

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

    public void StopTimer()
    {
        StopCoroutine(startRitardoLancio);
    }
}
