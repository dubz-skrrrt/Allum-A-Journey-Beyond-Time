using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    [SerializeField] Player player;
    public int sceneNum;
    public string sceneName;
    public bool sceneSwitchSave;
    public bool start;
    public bool canWalk;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
        if (!File.Exists(Application.persistentDataPath +  "/SaveFile_" + SaveSlotData.SlotName + ".dat"))
        {
            //save file on playmode in Unity
            if (SaveSlotData.SlotName == null)
            {
                SaveSlotData.SlotName = "test";
            }
            Debug.Log(SaveSlotData.SlotName);

            SceneSwitchData();
            SavePlayer();
        }
        
        
    }
    private void Start()
    {
        if (File.Exists(Application.persistentDataPath +  "/SaveFile_" + SaveSlotData.SlotName + ".dat") && !sceneSwitchSave)
        {
            LoadPlayer();
            SavePlayer();
        }
        
    }

    private void Update()
    {
        if (start)
        {
            start = false;
            canWalk = true;
        }
                
    }
    public void SceneSwitchData()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        sceneNum = SceneManager.GetActiveScene().buildIndex;
        sceneName = SceneManager.GetActiveScene().name;
        //sceneSwitchSave = false;
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
        player.isFacingRight = data.isfacing;
        canWalk = data.wakingup;
        Vector3 scale = player.transform.localScale;
        scale.x = data.facingRight[0];
        scale.y = data.facingRight[1];
        scale.z = data.facingRight[2];
        player.transform.localScale = scale;
        Vector3 position = player.transform.position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        player.transform.position = position;
    }
}
