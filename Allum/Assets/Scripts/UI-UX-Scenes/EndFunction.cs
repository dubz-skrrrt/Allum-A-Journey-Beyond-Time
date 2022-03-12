using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndFunction : MonoBehaviour
{
    public void BackToMenu()
    {
        Loader.load("MainMenu");
    }
}
