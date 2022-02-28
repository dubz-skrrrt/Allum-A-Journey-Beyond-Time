using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] private bool playerDetected;
    [SerializeField] private string nameOfScene;
    private bool sceneChanged;
    public Transform doorPos;
    public float width;
    public float height;
    public LayerMask thisisPlayer;
    [SerializeField] SwitchSceneLoader switchSceneLoader;
    [SerializeField] SaveManager saveManager;
    private void Awake()
    {
        switchSceneLoader = FindObjectOfType<SwitchSceneLoader>();
    }
    private void Start()
    {
        saveManager = FindObjectOfType<SaveManager>();
        saveManager.SceneSwitchData();
    }
    private void Update()
    {
        playerDetected = Physics2D.OverlapBox(doorPos.position, new Vector2(width, height), 0, thisisPlayer);
        if (saveManager.sceneSwitchSave)
        {
            saveManager.SavePlayer();
            saveManager.sceneSwitchSave = false;
        }
        if (playerDetected)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                switchSceneLoader.SwitchScene(nameOfScene);
                saveManager.sceneSwitchSave = true;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(doorPos.position, new Vector3(width, height, 10));
    }
}
