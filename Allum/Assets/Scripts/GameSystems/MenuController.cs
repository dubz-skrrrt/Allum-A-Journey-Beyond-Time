using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject MenuPanel;
    [SerializeField] GameObject SlotSelectPanel;
    [SerializeField] MenuButtonController menuButtonController;
    public static bool isStartPressed;
    public static bool isReturn;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            OnClickEscape();
        }
    }

    public void OnClickEscape()
    {
        isReturn = true;
        MainMenuEnabled();
    }
    public void SelectPanelEnabled()
    {
        MenuPanel.SetActive(false);
        SlotSelectPanel.SetActive(true);
    }

    public void MainMenuEnabled()
    {
        MenuPanel.SetActive(true);
        SlotSelectPanel.SetActive(false);
        isReturn = false;
    }

    public void SaveNewGame()
    {
        SceneManager.LoadScene("GameScene");
    }

}
