using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSceneTrigger : MonoBehaviour
{
    SwitchSceneLoader switchSceneLoader;
    [SerializeField] private string sceneName;
    private void Start()
    {
        switchSceneLoader = FindObjectOfType<SwitchSceneLoader>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            switchSceneLoader.SwitchScene(sceneName);
        }
    }
}
