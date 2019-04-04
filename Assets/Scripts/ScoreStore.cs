//Use this script to fetch the settings and show them as text on the screen.

using UnityEngine;
using UnityEngine.UI;

public class ScoreStore : MonoBehaviour
{
    int m_Score;

    public int updateScore;
    private int incScore;

    void Start()
    {
        //Fetch the PlayerPref settings
        GetText();
        Debug.Log("Score: " + m_Score);
    }


    void Update()
    {
        GetText();
    }



    

    void SetText()
    {
        incScore = m_Score + updateScore;
        PlayerPrefs.SetInt("Score", 0);
    }

    void GetText()
    {
        //Fetch the score from the PlayerPrefs (set these Playerprefs in another script). If no Int of this name exists, the default is 0.
        m_Score = PlayerPrefs.GetInt("Score", 0);
    }

    void OnGUI()
    {
        //Fetch the PlayerPrefs settings and output them to the screen using Labels
        GUI.Label(new Rect(50, 130, 200, 30), "Score : " + m_Score);
    }
}