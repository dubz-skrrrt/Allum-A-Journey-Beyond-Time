using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSceneManager : MonoBehaviour
{
    public void newGame()
    {
        Loader.load(Loader.Scene.GameScene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
