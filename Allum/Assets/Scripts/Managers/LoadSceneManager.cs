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
        Loader.load(scene);
    }

    public void loadGame(string sceneName)
    {
        Loader.load(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
