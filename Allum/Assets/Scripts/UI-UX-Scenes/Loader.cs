using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public static class Loader
{
    private class LoadingMonoBehavior : MonoBehaviour { }
    public enum Scenes {
        IntroScene,
        Loading,
        MainMenu,
        GameScene,
    }
    private static Action onLoaderCallback;
    public static void load(Scene scene)
    {
        // Set the loader callback action to load the target scenes
        onLoaderCallback = () => {
            GameObject loadingGameObject = new GameObject("Loading Game Object");
            loadingGameObject.AddComponent<LoadingMonoBehavior>().StartCoroutine(LoadScenesAsync(scene));
        };
        // load the loading scene each time scene changes
        SceneManager.LoadScene(Scenes.Loading.ToString());
    }
    private static IEnumerator LoadScenesAsync(Scene scene)
    {
        yield return null;
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene.ToString());

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

