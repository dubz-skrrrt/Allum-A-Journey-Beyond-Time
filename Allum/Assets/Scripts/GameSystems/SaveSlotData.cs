using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.IO;
using TMPro;
public class SaveSlotData : MonoBehaviour
{
    public static SaveSlotData _instance;
    public static SaveSlotData Instance 
    { 
        get { return _instance; } 
    } 
    public static string SlotName;
    public GameObject slotImage;
    public bool slotEmpty;
    public GameObject slotEmptyTxt;
    public GameObject slotInfo;
    public GameObject chapterNum;
    public TextMeshProUGUI sceneName;
    public GameObject dateSaved;
    public GameObject hoursPlayed;
    public int SlotNumber;
    private void Awake()
    {
        //  if (_instance != null && _instance != this) 
        // { 
        //     return;
        // }

        //_instance = this;
        DontDestroyOnLoad(this.gameObject);
         if (File.Exists(Application.persistentDataPath +  "/SaveFile_" + this.gameObject.name + ".dat"))
        {
            slotEmpty = true;
            if (slotEmpty)
            {
                slotEmptyTxt.SetActive(false);
                slotInfo.SetActive(true);
                SlotDataRead();
            }
        }

        
    }
    public void SlotSavedIn()
    {
        GameObject slot = EventSystem.current.currentSelectedGameObject;
        SlotName = slot.name;
    }
    public void SlotDataRead()
    {
        PlayerData data = SaveSystem.LoadGameState(this.gameObject.name);
        sceneName.text = data.SceneName;
        
    }
}
