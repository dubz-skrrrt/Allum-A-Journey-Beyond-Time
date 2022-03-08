using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    [SerializeField] Player player;
    public PlayerData data;
    public List<string> NPCs = new List<string>();
    public int sceneNum;
    public string sceneName;
    public bool sceneSwitchSave;
    public bool start;
    public bool canWalk;
    public bool inMenu;
    public bool FirstMissionComplete;
    public bool SecondMissionStart;
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
            Debug.Log("LoadedPlayer");
            LoadPlayerMissionData();
            SceneSwitchData();
            LoadPlayer();
            SavePlayer();
            
        }
        //  if (File.Exists(Application.persistentDataPath +  "/SaveFile_" + SaveSlotData.SlotName + ".dat") && sceneSwitchSave)
        // {
        //     Debug.Log("LoadedPlayer");
        //     LoadPlayerMissionData();
        //     SceneSwitchData();
        //     SavePlayer();
        //     sceneSwitchSave = false;
        // }
        
    }

    private void Update()
    {
        if (start)
        {
            canWalk = true;
            SavePlayer();
        }
        
        if (inMenu)
        {
            Destroy(instance.gameObject);
            inMenu = false;
        }
    }
    public void SceneSwitchData()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        sceneNum = SceneManager.GetActiveScene().buildIndex;
        sceneName = SceneManager.GetActiveScene().name;
        player.transform.position = player.transform.position;
    }
    public void SavePlayer()
    {
        Debug.Log("Saved");
        SaveSystem.SaveGameState(player, SaveSlotData.SlotName);
        start = false;
    }

    public void LoadPlayer()
    {
        data = SaveSystem.LoadGameState(SaveSlotData.SlotName);
        sceneNum = data.SceneIndex;
        sceneName = data.SceneName;
        player.isFacingRight = data.isfacing;
        NPCs = data.NPCNames;
        foreach (string NPCname in data.NPCNames)
        {
            Debug.Log("Loaded" + NPCname);
            if (NPCDIalogueChecker.NPCName == NPCname)
            {
                Debug.Log("thisDone" + " " + NPCname);
                NPCDIalogueChecker.NPCDialogueDone = data.dialogueDone;
                if (NPCDIalogueChecker.NPCDialogueDone)
                {
                    player.DialogueIsDone = true;
                }
            }
        }
        SceneFader.faded = data.fade;
        DialogueTrigger.walkedAway = data.walkingAway;
        TimePiece.timepieceAppear = data.timePieceOn;
        canWalk = data.wakingup;
        FrameSwitchingSystem.pastTime = data.pastFrames;
        FirstMissionComplete = data.firstMission;
        SecondMissionStart = data.secondMisson;
        //Character local scale
        Vector3 scale = player.transform.localScale;
        scale.x = data.facingRight[0];
        scale.y = data.facingRight[1];
        scale.z = data.facingRight[2];
        player.transform.localScale = scale;
        //Character position
        Vector3 position = player.transform.position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        player.transform.position = position;
    }

    public void LoadPlayerMissionData()
    {
        data = SaveSystem.LoadGameState(SaveSlotData.SlotName);
        sceneNum = data.SceneIndex;
        NPCs = data.NPCNames;
        foreach (string NPCname in data.NPCNames)
        {
            Debug.Log("Loaded data NPC name: " + NPCname +  " Scene NPC name: " + NPCDIalogueChecker.NPCName);
            if (NPCDIalogueChecker.NPCName == NPCname)
            {
                Debug.Log("thisDone");
                NPCDIalogueChecker.NPCDialogueDone = data.dialogueDone;
                if (NPCDIalogueChecker.NPCDialogueDone)
                {
                    player.DialogueIsDone = true;
                }
            }
        }
        DialogueTrigger.walkedAway = data.walkingAway;
        SceneFader.faded = data.fade;
        sceneName = data.SceneName;
        canWalk = data.wakingup;
        TimePiece.timepieceAppear = data.timePieceOn;
        FirstMissionComplete = data.firstMission;
        SecondMissionStart = data.secondMisson;
        FrameSwitchingSystem.pastTime = data.pastFrames;
    }
}
