using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public static class Loader
{
    private class LoadingMonoBehavior : MonoBehaviour { }
    public static string SceneName;
    // public enum Scene {
    //     Loading,
    //     MainMenu,
    //     Apartment,
    //     Outside,
    // }
    private static Action onLoaderCallback;
    public static void load(string scene)
    {
        // Set the loader callback action to load the target scenes
        onLoaderCallback = () => {
            GameObject loadingGameObject = new GameObject("Loading Game Object");
            loadingGameObject.AddComponent<LoadingMonoBehavior>().StartCoroutine(LoadScenesAsync(scene));
        };
        // load the loading scene each time scene changes
        SceneManager.LoadScene("Loading");
    }
    private static IEnumerator LoadScenesAsync(string scene)
    {
        yield return null;
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene);

        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }
    public static void LoaderCallBack()
    {
        // Triggered after the first update whih lets the screen refresh
        // Execute the loader callback ation which will load the target scene 
        if (onLoaderCallback != null)
        {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }
}

