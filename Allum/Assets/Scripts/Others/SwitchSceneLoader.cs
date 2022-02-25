using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SwitchSceneLoader : MonoBehaviour
{
    public static string prevScene;
    public static string currentScene;
    public virtual void Start()
    { 
        GetCurrentScene();
    }

    public void GetCurrentScene()
    {
        currentScene = SceneManager.GetActiveScene().name;
        Debug.Log(currentScene);
    }
    public void SwitchScene(string sceneName)
    {
        
        prevScene = currentScene;
        Debug.Log(prevScene);
        Loader.load(sceneName);
    }
}
