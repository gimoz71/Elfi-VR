using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

    //public string sceneSelect;
    //public int selectScene;

    static public int team;
    static public int scene;

    public int getTeam;
    public int getScene;

     public void sceneChange()
    {
        team = getTeam;
        scene = getScene;
        SceneManager.LoadScene("Caverna");
    }

    public void nextScene()
    {
        Debug.Log("sfgfgfd");
        scene = scene + 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void sceneIntro()
    {
        SceneManager.LoadScene("Intro");
    }
}
