using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    private GameObject countDownPanel; // pannello countdown
    public Text startStopText;
    public TextMeshProUGUI countDown;
    Coroutine startRitardoLancio;
    private float duration;
    public float tempo;
    private bool isPaused;


    // Start is called before the first frame update
    void Start()
    {
        countDownPanel = GameObject.Find("[COUNTDOWN]");
        isPaused = true;
        startStopText.text = "Timer start";
        StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTimer()
    {
        startRitardoLancio = StartCoroutine(ritardoLancio(tempo));
    }

    public IEnumerator ritardoLancio(float myDelay)
    {
        //countDownPanel.SetActive(true);
        

        duration = myDelay;
            
        countDown.text = "" + duration;
        while (duration > 0)
        {
            while (isPaused)
            {
                yield return null;
            }
            
            yield return new WaitForSeconds(1);
            duration--;
            countDown.text = "" + duration;

            while (isPaused)
            {
                yield return null;
            }
        }
        //yield return new WaitForSeconds(myDelay);
        //yield return StartCoroutine(sequenzaLancio(myQuantity, myInterval));
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

 

    public void ResetTimer()
    {
        duration = tempo;
        countDown.text = "" + duration;
    }

    public void StartPauseTimer()
    {
        if(isPaused == true)
        {
            startStopText.text = "Timer pause";
            isPaused = false;
        } else
        {
            startStopText.text = "Timer start";
            isPaused = true;
        }
            
    }
}
