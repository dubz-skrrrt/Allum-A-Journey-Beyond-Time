using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public Player player;
    public int sceneNum;
    public string sceneName;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        sceneNum = SceneManager.GetActiveScene().buildIndex;
        sceneName = SceneManager.GetActiveScene().name;
        if (!File.Exists(Application.persistentDataPath +  "/SaveFile_" + SaveSlotData.SlotName + ".dat"))
        {
            Debug.Log(SaveSlotData.SlotName);
            SavePlayer();
        }
        
    }
    private void Start()
    {
        LoadPlayer();
        SavePlayer();
    }

    private void Update()
    {
        
    }


    public void SavePlayer()
    {
        SaveSystem.SaveGameState(player, SaveSlotData.SlotName);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadGameState(SaveSlotData.SlotName);
        sceneNum = data.SceneIndex;
        sceneName = data.SceneName;
        Vector3 position = player.transform.position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        player.transform.position = position;
    }
}
