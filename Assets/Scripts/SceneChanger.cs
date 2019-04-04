using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

    public string sceneSelect;

     public void sceneChange()
    {
        SceneManager.LoadScene(sceneSelect);
    }
}
