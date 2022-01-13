using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public enum Scenes {
        IntroScene,
        MainMenu,
        GameScene,
    }

    public static void load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}

