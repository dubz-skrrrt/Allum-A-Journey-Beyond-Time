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
        if (playerDetected)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SaveManager.instance.sceneSwitchSave = true;
                StartCoroutine(DelayOpen());
                
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(doorPos.position, new Vector3(width, height, 10));
    }

    IEnumerator DelayOpen()
    {
        Player.current.movementDisabled = true;
        yield return new WaitForSeconds(1f);
        switchSceneLoader.SwitchScene(nameOfScene);
    }
}
