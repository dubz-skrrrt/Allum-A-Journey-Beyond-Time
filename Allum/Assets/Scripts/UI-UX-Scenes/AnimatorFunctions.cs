using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class AnimatorFunctions : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] MenuController menuController;
    [SerializeField] LoadSceneManager loadSceneManager;
    public bool disableOnce; 

    public void EnableSavePanel()
    {
        if (menuButtonController.index == 0 && MenuController.isStartPanel)
        {
            menuController.GetComponent<Animation>().Play("MenuTransition");
        }
        
    }

    public void QuitGame()
    {
        if (menuButtonController.index == 2 && MenuController.isStartPanel)
        {
            Application.Quit();
        }
    }
    public void startGame()
    {
        if (File.Exists(Application.persistentDataPath +  "/SaveFile_" + SaveSlotData.SlotName + ".dat"))
        {
            Debug.Log("HasFile");
            PlayerData data = SaveSystem.LoadGameState(SaveSlotData.SlotName);
            
            loadSceneManager.loadGame(data.SceneName);
        }
        else
        {
            Debug.Log("NoFile");
            loadSceneManager.newGame("Apartment");
        }
        
    }
}
