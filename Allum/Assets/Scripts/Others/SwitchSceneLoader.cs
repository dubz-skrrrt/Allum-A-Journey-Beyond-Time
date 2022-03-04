using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SwitchSceneLoader : MonoBehaviour
{
    public static string prevScene;
    public static string currentScene;
    public bool DialogueSceneDone;
    public static SwitchSceneLoader instance;
    private void Awake()
    {
        instance = this;
    }
    public virtual void Start()
    { 
        GetCurrentScene();
    }
    private void Update()
    {
        if (InteractionSystem.instance.interacting && !Player.current.DialogueIsDone)
        {
            DialogueSceneDone = true;
        }
    }
    public void GetCurrentScene()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }
    public void SwitchScene(string sceneName)
    {
        prevScene = currentScene;
        Loader.load(sceneName);
    }
}
