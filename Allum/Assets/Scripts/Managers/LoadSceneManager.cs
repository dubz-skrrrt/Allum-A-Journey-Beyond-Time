using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSceneManager : MonoBehaviour
{
    public static LoadSceneManager instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public void newGame(string scene)
    {
        SceneFader.instance.FadeToScene(scene);
    }

    public void loadGame(string sceneName)
    {
        SceneFader.instance.FadeToScene(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
